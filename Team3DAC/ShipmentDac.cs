using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;

namespace Team3DAC
{
    public class ShipmentDac : ConnectionAccess
    {
        /// <summary>
        /// 고객별 주문현황
        /// </summary>
        /// <returns></returns>
        public List<ShipmentVO> GetInventoryStatusByOrder()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetInventoryStatusByOrder";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShipmentVO> list = Helper.DataReaderMapToList<ShipmentVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

       
        public List<ShipmentOutVO> GetClientOrder()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                
                string sql = @"select so_id,plan_id,c.company_name,s.product_name as product_codename,p.product_name,so_pcount,p.product_id,s.company_code,s.so_ocount,
(select distinct w.w_count_present
from TBL_WAREHOUSE w
inner join TBL_WAREHOUSE w1 on w.plan_id = s.plan_id and w.product_id = p.product_id
inner join TBL_FACTORY f on w.factory_id = f.factory_id and f.factory_type = 'FAC700') as orderable_count
from TBL_SO_MASTER s inner join TBL_COMPANY c on  s.company_code=c.company_code
               inner join TBL_PRODUCT p on p.product_codename=s.product_name";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShipmentOutVO> list = Helper.DataReaderMapToList<ShipmentOutVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// 이동수량 개수만큼 이동처리
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool TransferProcessing(List<ShipmentVO> list)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "TransferProcessing";
                    //int num = 1;

                    foreach (var item in list)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@factory_name", item.factory_name);
                        cmd.Parameters.AddWithValue("@product_id", item.product_id);
                        cmd.Parameters.AddWithValue("@w_count_present", item.w_count_present);
                        cmd.Parameters.AddWithValue("@wh_uadmin", item.uadmin);//TODO : admin -> 실제 수정자
                        //if (item.wh_comment == null)
                        //{
                        //    cmd.Parameters.AddWithValue("@wh_comment", "");
                        //}
                        //else
                        //{
                        //    cmd.Parameters.AddWithValue("@wh_comment", item.wh_comment);
                        //}
                        cmd.Parameters.AddWithValue("@wh_category", item.category);
                        cmd.Parameters.AddWithValue("@wh_udate", DateTime.Now.ToString("yyyy-MM-dd"));

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
        /// 마감개수 처리만큼 마감처리
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool EndProcessing(List<ShipmentOutVO> list)
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

                   
                    foreach (var item in list)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@s_count", item.s_count);
                        cmd.Parameters.AddWithValue("@product_id", item.product_id);
                        cmd.Parameters.AddWithValue("@s_company", item.company_code);
                        cmd.Parameters.AddWithValue("@so_id", item.so_id);
                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@s_date", item.s_date);
                        
                        cmd.CommandText = @"select company_id from TBL_COMPANY where company_code = @s_company";//companycode로 company_id조회

                        int company_id = Convert.ToInt32(cmd.ExecuteScalar());  

                        cmd.Parameters.AddWithValue("@company_id", company_id);

                        //해당 품번과 업체id로 product의 현재단가를 검색 TODO 안되면 주석해제
                        //cmd.CommandText = @"select price_present from TBL_P_PRICE where product_id = @product_id and company_id = @company_id and price_edate = '9999-12-31'";

                        //int price = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.AddWithValue("@s_TotalPrice", item.s_totalprice);    //마감개수*품목의 현재단가

                        
                        cmd.CommandText = @"insert into TBL_SALES_COMPLETE(s_date, so_id, product_id, plan_id, s_count, s_TotalPrice, s_company) values (@s_date, @so_id, @product_id, @plan_id, @s_count, @s_TotalPrice, @s_company)";
                        cmd.ExecuteNonQuery();  //마감처리테이블에 마감 이력 등록

                        cmd.CommandText = @"update TBL_SO_MASTER set so_ocount = so_ocount + @s_count where so_id = @so_id";
                        cmd.ExecuteNonQuery();//영업마스터테이블의 ocount업데이트(마감수량만큼)

                        //w_id조회해오기
                        cmd.CommandText = @"select w_id from TBL_WAREHOUSE w inner join TBL_FACTORY f on f.factory_id = w.factory_id where plan_id = @plan_id and product_id = @product_id and f.factory_type = 'FAC700'";

                        int w_id = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.AddWithValue("@w_id", w_id);

                        //warehouse테이블의 해당 w_id의 고객사창고의 재고 수정(자재차감)
                        cmd.CommandText = @"update TBL_WAREHOUSE set w_count_present = w_count_present - @s_count, w_count_past = w_count_present where w_id = @w_id";
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.AddWithValue("@wh_udate", DateTime.Now.ToShortDateString());


                        cmd.CommandText = @"select w_id from TBL_WAREHOUSE w inner join TBL_FACTORY f on f.factory_id = w.factory_id where plan_id = @plan_id and product_id = @product_id and f.factory_type = 'FAC400'";
                        int w_id_fac400 = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.Parameters.AddWithValue("@w_id_fac400", w_id_fac400);
                        //warehouse_his테이블에 고객사창고에서 매출마감되는 자재차감 이력 등록
                        cmd.CommandText = "insert into TBL_WAREHOUSE_HIS(w_id, product_id,  wh_product_count, wh_udate, wh_comment, wh_category) values (@w_id_fac400, @product_id, @s_count, @wh_udate, '자재차감', 'P_MOVE_ITEM')";
                        cmd.ExecuteNonQuery();

                        //warehouse_his테이블에 매출마감 이력 등록

                        cmd.CommandText = "insert into TBL_WAREHOUSE_HIS(w_id, product_id,  wh_product_count, wh_udate, wh_comment, wh_category) values (@w_id, @product_id, @s_count, @wh_udate, '매출마감', 'P_SALES_COMPLETE')";
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
        /// 해당 product_id의 현재단가 조회
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public int GetPresentPrice(int product_id)
        {
            int price_present = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"select price_present
from TBL_P_PRICE pr inner
join TBL_PRODUCT p on pr.product_id = p.product_id
where price_edate = '9999-12-31' and product_type = 'FP' and pr.product_id = @product_id";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@product_id", product_id);
                price_present = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Connection.Close();
                return price_present;

            }
        }

        /// <summary>
        /// 마감현황조회
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public DataTable GetSalesCompleteStatus()
        {
          
            using (SqlCommand cmd = new SqlCommand())
            {
                DataTable dt = new DataTable();
                string sql = @"select s.so_id,s_date,s.plan_id,p.product_codename,p.product_name,s_count,s_TotalPrice,s_company,c.company_name,so.so_pcount
from TBL_SALES_COMPLETE s  inner
join TBL_PRODUCT p on s.product_id = p.product_id
inner
join TBL_SO_MASTER so on s.so_id = so.so_id
inner
join TBL_COMPANY c on c.company_code = s.s_company";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                da.Dispose();

                cmd.Connection.Close();
                return dt;

            }
        }
    }
}

