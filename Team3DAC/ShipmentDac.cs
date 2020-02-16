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
                        if (item.wh_comment == null)
                        {
                            cmd.Parameters.AddWithValue("@wh_comment", "");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@wh_comment", item.wh_comment);
                        }
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

                    //int num = 1;

                    foreach (var item in list)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@s_company", item.company_code);
                        cmd.Parameters.AddWithValue("@so_id", item.so_id);
                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@s_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        cmd.CommandText = @"select company_id from TBL_COMPANY where company_code = @company_code";

                        int company_id = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.AddWithValue("@product_id", item.product_id);
                        cmd.Parameters.AddWithValue("@company_id", company_id); 

                        cmd.CommandText = @"select price_present from TBL_P_PRICE where product_id = @product_id and company_id = @company_id and price_edate = '9999-12-31'";

                        int price = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.AddWithValue("@s_count", item.incount);
                        cmd.Parameters.AddWithValue("@s_TotalPrice", price * item.incount);

                        cmd.CommandText = @"insert into TBL_SALES_COMPLETE(s_date, so_id, product_id, plan_id, s_count, s_TotalPrice, s_company) values (@s_date, @so_id, @product_id, @plan_id, @s_count, @s_TotalPrice, @s_company)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"update TBL_SO_MASTER set so_ocount = so_ocount + @incount where so_id = @so_id";
                        cmd.ExecuteNonQuery();
                            
                        cmd.CommandText = @"select w_id from TBL_WAREHOUSE w inner join TBL_FACTORY f on f.factory_id = w.factory_id where plan_id = @plan_id and product_id = @product_id and f.factory_type = 'FAC700'";

                        int w_id = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.AddWithValue("@w_id", item.w_id);

                        cmd.CommandText = @"update TBL_WAREHOUSE set w_count_present = w_count_present - @incount, w_count_past = w_count_present where w_id = @w_id";
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.AddWithValue("@wh_udate", DateTime.Now.ToShortDateString());

                        cmd.CommandText = "insert into TBL_WAREHOUSE_HIS(w_id, product_id,  wh_product_count, wh_udate, wh_comment, wh_category) values (@w_id, @product_id, @incount, @wh_udate, '매출마감', 'P_SALES_COMPLETE')";
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
    }
}

