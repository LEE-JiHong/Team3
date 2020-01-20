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

                        cmd.CommandText = @"insert into TBL_SO_MASTER(plan_id, so_od_id, so_wo_id, company_code, company_type, product_name, so_pcount, so_edate, so_sdate) " +
                    "values(@plan_id, @so_od_id, @so_wo_id, @company_code, @company_type, @product_name, @so_pcount, @so_edate, @so_sdate)";

                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@so_od_id", item.so_od_id);
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
        public List<SOMasterVO> GetSOMasterAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT so_id, plan_id, so_od_id, so_wo_id, company_code, company_type, product_name, so_pcount, so_ocount, so_ccount, so_edate, so_sdate, so_uadmin, so_udate, so_comment FROM TBL_SO_MASTER ORDER BY plan_id ASC";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<SOMasterVO> list = Helper.DataReaderMapToList<SOMasterVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

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

        //public bool UpdateSOMaster(SOMasterVO vo)
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        string sql = "UpdateSOMaster";

        //        cmd.Connection = new SqlConnection(this.ConnectionString);
        //        cmd.CommandText = sql;
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@product_id", vo.product_id);

        //        cmd.Connection.Open();
        //        var successRow = cmd.ExecuteNonQuery();
        //        cmd.Connection.Close();
        //        return successRow > 0;
        //    }
        //}
    }
}
