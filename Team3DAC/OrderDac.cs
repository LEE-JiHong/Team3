using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Team3VO;

namespace Team3DAC
{
    public class OrderDac : ConnectionAccess
    {
        /// <summary>
        /// 업로드한 영업마스터를 기준으로 영업마스터 생성(insert)
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool AddSOMaster(List<SOMasterVO> list)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;

                    foreach (SOMasterVO item in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@company_code", item.company_code);

                        cmd.CommandText = @"select company_type from TBL_COMPANY where company_code = @company_code";

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            item.company_type = reader["company_type"].ToString();
                        }
                        reader.Close();

                        cmd.CommandText = @"insert into TBL_SO_MASTER(plan_id, so_wo_id, company_code, company_type, product_name, so_pcount, so_edate, so_sdate, so_ocount, so_ccount) " +
                    "values(@plan_id, @so_wo_id, @company_code, @company_type, @product_name, @so_pcount, @so_edate, @so_sdate, 0, 0)";

                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@so_wo_id", item.so_wo_id);
                        cmd.Parameters.AddWithValue("@company_type", item.company_type);
                        cmd.Parameters.AddWithValue("@product_name", item.product_name);
                        cmd.Parameters.AddWithValue("@so_pcount", item.so_pcount);
                        cmd.Parameters.AddWithValue("@so_edate", item.so_edate);
                        cmd.Parameters.AddWithValue("@so_sdate", item.so_sdate);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    cmd.Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    tran.Rollback();
                    cmd.Connection.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 영업마스터 조회
        /// </summary>
        /// <returns></returns>
        public List<SOMasterVO> GetSOMasterAll(WhereSoVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //string sql = "SELECT so_id, plan_id, so_wo_id, company_code, company_type, product_name, so_pcount, so_ocount, so_ccount, so_edate, so_sdate, so_uadmin, so_udate, so_comment FROM TBL_SO_MASTER ORDER BY plan_id ASC";

                StringBuilder sql = new StringBuilder();
                    
                    sql.Append("select so_id, so_wo_id, s.company_code, company_name, p.product_name, p.product_codename, so_pcount, so_ccount, so_ocount, so_comment, so_edate, so_sdate, so_uadmin, so_udate from dbo.TBL_SO_MASTER s inner join dbo.TBL_COMPANY c on s.company_code = c.company_code inner join dbo.TBL_PRODUCT p on s.product_name = p.product_codename where CONVERT (DATETIME, so_edate) >= CONVERT (DATETIME, @startDate) and CONVERT (DATETIME, so_edate) <= CONVERT (DATETIME, @endDate) and CONVERT (DATETIME, so_sdate) >= CONVERT (DATETIME, @regstartDate) and CONVERT (DATETIME, so_sdate) <= CONVERT (DATETIME, @regendDate)");

                if (vo.CompanyName != null)
                {
                    sql.Append(" and company_name = @company_name");
                    cmd.Parameters.AddWithValue("@company_name", vo.CompanyName);
                }

                //p.product_codename을 product_name으로 바꾸기

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@startDate", vo.startDate);
                cmd.Parameters.AddWithValue("@endDate", vo.endDate);
                cmd.Parameters.AddWithValue("@regstartDate", vo.RegStartDate);
                cmd.Parameters.AddWithValue("@regendDate", vo.RegEndDate);

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<SOMasterVO> list = Helper.DataReaderMapToList<SOMasterVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// 업체 조회
        /// </summary>
        /// <param name="company_type">{company_type}이 아닌 업체 조회</param>
        /// <returns></returns>
        public List<CompanyVO> GetCompanyAll(string company_type)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = $"select * from TBL_COMPANY where company_type != '{company_type}'";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// '완제품'인 제품 조회
        /// </summary>
        /// <returns></returns>
        public List<ProductVO> GetProductList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select * from TBL_PRODUCT where product_type = 'FP'";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProductVO> list = Helper.DataReaderMapToList<ProductVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// planID 가져오기
        /// </summary>
        /// <returns></returns>
        public List<string> GetPlanID()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select distinct plan_id from TBL_SO_MASTER where CONVERT(DATETIME, so_edate) >= CONVERT(DATETIME, @to_date)";

                cmd.Parameters.AddWithValue("@to_date", DateTime.Now.ToShortDateString());

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> list = new List<string>();

                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }

                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// planID 있는지 체크
        /// </summary>
        /// <returns></returns>
        public int GetPlanIDINSOMaster(string planID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select count(*) from TBL_SO_MASTER where plan_id = @planID";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@planID", planID);

                cmd.Connection.Open();

                int resultNum = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Connection.Close();
                return resultNum;
            }
        }

        /// <summary>
        /// 영업마스터 수작업으로 등록
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool AddOneSOMaster(SOMasterVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "insert into TBL_SO_MASTER(plan_id, so_wo_id, company_code, company_type, product_name, so_pcount, so_edate, so_sdate, so_ocount, so_ccount, so_comment) " +
                    "values(@plan_id, @so_wo_id, @company_code, @company_type, @product_name, @so_pcount, @so_edate, @so_sdate, 0, 0, @so_comment)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@plan_id", VO.plan_id);
                cmd.Parameters.AddWithValue("@so_wo_id", VO.so_wo_id);
                cmd.Parameters.AddWithValue("@company_code", VO.company_code);
                cmd.Parameters.AddWithValue("@company_type", VO.company_type);
                cmd.Parameters.AddWithValue("@product_name", VO.product_name);
                cmd.Parameters.AddWithValue("@so_pcount", VO.so_pcount);
                cmd.Parameters.AddWithValue("@so_edate", VO.so_edate);
                cmd.Parameters.AddWithValue("@so_sdate", VO.so_sdate);
                cmd.Parameters.AddWithValue("@so_comment", VO.so_comment);

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }

        /// <summary>
        /// 영업마스터 수정
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool UpdateOneSOMaster(SOMasterVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update TBL_SO_MASTER set company_code = @company_code, company_type = @company_type, product_name = @product_name, so_pcount = @so_pcount, so_ccount=@so_ccount, so_comment = @so_comment, so_udate = @so_udate, so_edate = @so_edate where so_id = @so_id";

                    cmd.Parameters.AddWithValue("@company_code", VO.company_code);
                    cmd.Parameters.AddWithValue("@company_type", VO.company_type);
                    cmd.Parameters.AddWithValue("@product_name", VO.product_codename);
                    cmd.Parameters.AddWithValue("@so_pcount", VO.so_pcount);
                    cmd.Parameters.AddWithValue("@so_ccount", VO.so_ccount);
                    cmd.Parameters.AddWithValue("@so_comment", VO.so_comment);
                    cmd.Parameters.AddWithValue("@so_udate", VO.so_udate);
                    cmd.Parameters.AddWithValue("@so_id", VO.so_id);
                    cmd.Parameters.AddWithValue("@so_edate", VO.so_edate);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update TBL_DEMAND_PLAN set d_date = @so_edate where so_id = @so_id";

                    cmd.ExecuteNonQuery();

                    tran.Commit();
                    cmd.Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    tran.Rollback();
                    cmd.Connection.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// firstdate와 enddate에 맞춰서 날짜 가져오기
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<DayVO> GetDays(string firstDate, string endDate)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetDays";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstDate", firstDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<DayVO> list = Helper.DataReaderMapToList<DayVO>(reader);

                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// planID로 검색하여 영업마스터 가져오기
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        public List<SOMasterVO> GetSOMaster(string planID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select so_id, so_wo_id, s.company_code, company_name, p.product_name, p.product_codename, so_pcount, so_ccount, so_ocount, so_comment, so_edate, so_sdate, so_uadmin, so_udate from dbo.TBL_SO_MASTER s inner join dbo.TBL_COMPANY c on s.company_code = c.company_code inner join dbo.TBL_PRODUCT p on s.product_name = p.product_codename WHERE plan_id = @PlanID order by so_edate desc";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PlanID", planID);

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<SOMasterVO> list = Helper.DataReaderMapToList<SOMasterVO>(reader);

                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// planID로 검색하여 생산계획 가져오기
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        public List<DemandPlanVO> GetDemandPlanFromPlanID(string planID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT * FROM TBL_DEMAND_PLAN WHERE plan_id = @PlanID order by d_date desc";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PlanID", planID);

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<DemandPlanVO> list = Helper.DataReaderMapToList<DemandPlanVO>(reader);

                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// planID로 검색하여 수요계획테이블에 해당 plan_id가 있는지 확인
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public int SearchPlanIDInDemand(string plan_id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "select count(*) from TBL_DEMAND_PLAN where plan_id = @plan_id";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@plan_id", plan_id);

                cmd.Connection.Open();
                int Row = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
                return Row;
            }
        }

        ///// <summary>
        ///// 수요계획 생성(생산계획도 동시에 insert)
        ///// </summary>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //public bool AddDemandPlan(List<DemandPlanVO> list)
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.Connection = new SqlConnection(this.ConnectionString);
        //        cmd.Connection.Open();
        //        SqlTransaction tran = cmd.Connection.BeginTransaction();

        //        try
        //        {
        //            cmd.Transaction = tran;
        //            cmd.CommandType = CommandType.Text;

        //            foreach (DemandPlanVO item in list)
        //            {
        //                cmd.Parameters.Clear();

        //                cmd.CommandText = @"insert into TBL_DEMAND_PLAN(so_id, plan_id, d_date, d_count) values (@so_id, @plan_id, @d_date, @d_count); SELECT @@IDENTITY";

        //                cmd.Parameters.AddWithValue("@so_id", item.so_id);
        //                cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
        //                cmd.Parameters.AddWithValue("@d_date", item.d_date);
        //                cmd.Parameters.AddWithValue("@d_count", item.d_count);

        //                int id = Convert.ToInt32(cmd.ExecuteScalar());

        //                cmd.CommandText = @"insert into TBL_PRODUCTION_PLAN(d_id, pro_udate) values (@d_id, @pro_udate)";
        //                cmd.Parameters.AddWithValue("@d_id", id);
        //                cmd.Parameters.AddWithValue("@pro_udate", DateTime.Now.ToShortDateString());
        //                cmd.ExecuteNonQuery();

        //            }

        //            tran.Commit();
        //            cmd.Connection.Close();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine(ex.Message);
        //            tran.Rollback();
        //            cmd.Connection.Close();
        //            return false;
        //        }
        //    }
        //}

        /// <summary>
        /// 수요계획 생성
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddDemandPlan(List<DemandPlanVO> list)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;

                    foreach (DemandPlanVO item in list)
                    {
                        cmd.Parameters.Clear();

                        cmd.CommandText = @"insert into TBL_DEMAND_PLAN(so_id, plan_id, d_date, d_count) values (@so_id, @plan_id, @d_date, @d_count)";

                        cmd.Parameters.AddWithValue("@so_id", item.so_id);
                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@d_date", item.d_date);
                        cmd.Parameters.AddWithValue("@d_count", item.d_count);

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    cmd.Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    tran.Rollback();
                    cmd.Connection.Close();
                    return false;
                }
            }
        }

        ///// <summary>
        ///// 생산계획 생성
        ///// </summary>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //public bool AddProductionPlan(string planID)
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.Connection = new SqlConnection(this.ConnectionString);
        //        cmd.Connection.Open();
        //        SqlTransaction tran = cmd.Connection.BeginTransaction();

        //        try
        //        {
        //            cmd.Transaction = tran;
        //            cmd.CommandType = CommandType.Text;

        //            cmd.CommandText = "select d_id from TBL_DEMAND_PLAN where plan_id = @PlanID";

        //            cmd.Parameters.AddWithValue("@PlanID", planID);

        //            List<int> list = new List<int>();

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                list.Add(Convert.ToInt32(reader[0]));
        //            }

        //            reader.Close();

        //            foreach (int dID in list)
        //            {
        //                cmd.Parameters.Clear();

        //                cmd.CommandText = @"insert into TBL_PRODUCTION_PLAN(d_id, pro_udate) values (@d_id, @pro_udate)";

        //                cmd.Parameters.AddWithValue("@d_id", dID);
        //                cmd.Parameters.AddWithValue("@pro_udate", DateTime.Now.ToShortDateString());
        //                cmd.ExecuteNonQuery();
        //            }

        //            tran.Commit();
        //            cmd.Connection.Close();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine(ex.Message);
        //            tran.Rollback();
        //            cmd.Connection.Close();
        //            return false;
        //        }
        //    }
        //}

        /// <summary>
        /// 생산계획 생성
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        public bool AddProductionPlan(List<ProductionPlanVO> list)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;

                    foreach (ProductionPlanVO item in list)
                    {
                        cmd.Parameters.Clear();

                        cmd.CommandText = @"insert into TBL_PRODUCTION_PLAN(d_id, pro_count, plan_id, pro_date, pro_udate) values (@d_id, @pro_count, @plan_id,@pro_date, @pro_udate)";

                        cmd.Parameters.AddWithValue("@d_id", item.d_id);
                        cmd.Parameters.AddWithValue("@pro_count", item.pro_count);
                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@pro_date", item.pro_date);
                        cmd.Parameters.AddWithValue("@pro_udate", DateTime.Now.ToShortDateString());

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    cmd.Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    tran.Rollback();
                    cmd.Connection.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 수요계획 목록 가져오기
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable GetDemandPlan(string firstDate, string endDate, string planID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetDemandPlan";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartDate", firstDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@plan_id", planID);

                DataTable dataTable = new DataTable();

                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
                da.Dispose();

                cmd.Connection.Close();
                return dataTable;
            }
        }


        public DataTable GetMRP(string planID, string firstDate, string endDate)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetMRPforOder";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@plan_id", planID);
                cmd.Parameters.AddWithValue("@StartDate", firstDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dataTable = new DataTable();

                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
                da.Dispose();

                cmd.Connection.Close();
                return dataTable;
            }
        }

        /// <summary>
        ///  planID로 UPH 조회
        /// </summary>
        /// <param name="plan_id"></param>
        /// <returns></returns>
        public int GetMaxUPHCount(string plan_id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "GetMaxUPHCount";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@plan_id", plan_id);

                cmd.Connection.Open();
                int Row = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
                return Row;
            }
        }

    }
}
