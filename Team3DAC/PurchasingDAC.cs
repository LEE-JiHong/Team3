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
    public class PurchasingDAC : ConnectionAccess
    {
        public DataSet GetOrderList(string planID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetOrder";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@plan_id", planID);

                cmd.Connection.Open();
                //SqlDataReader reader = cmd.ExecuteReader();

                //List<DayVO> list = Helper.DataReaderMapToList<DayVO>(reader);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                da.Dispose();

                cmd.Connection.Close();
                return ds;
            }
        }

        public bool InsertOrder(List<OrderVO> list)
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

                    int num = 1;

                    foreach (OrderVO item in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@product_codename", item.product_codename);

                        cmd.CommandText = @"select product_id from TBL_PRODUCT where product_codename = @product_codename";

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            item.product_id = Convert.ToInt32(reader["product_id"]);
                        }
                        reader.Close();

                        item.order_serial = DateTime.Now.ToShortDateString().Replace("-", "") + string.Format("{0:D4}", num);
                        num++;

                        cmd.CommandText = @"insert into TBL_ORDER (order_id, product_id, order_count, plan_id, order_serial, order_state, order_udate) values (@order_id, @product_id, @order_count, @plan_id, @order_serial, 'O_COMPLETE', @order_udate)";

                        cmd.Parameters.AddWithValue("@order_id", item.order_id);
                        cmd.Parameters.AddWithValue("@order_count", item.order_count);
                        cmd.Parameters.AddWithValue("@product_id", item.product_id);
                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@order_serial", item.order_serial);
                        cmd.Parameters.AddWithValue("@order_udate", DateTime.Now.ToShortDateString());

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
