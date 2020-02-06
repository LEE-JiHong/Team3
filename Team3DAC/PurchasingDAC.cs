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
        /// <summary>
        ///  정규발주 데이터그리드뷰 조회
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// OrderPop - 발주 insert
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
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

                        cmd.CommandText = @"insert into TBL_ORDER (order_id, product_id, order_count, plan_id, order_serial, order_state, order_udate, order_pdate) values (@order_id, @product_id, @order_count, @plan_id, @order_serial, 'O_COMPLETE', @order_udate, @order_pdate)";

                        cmd.Parameters.AddWithValue("@order_id", item.order_id);
                        cmd.Parameters.AddWithValue("@order_count", item.order_count);
                        cmd.Parameters.AddWithValue("@product_id", item.product_id);
                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@order_serial", item.order_serial);
                        cmd.Parameters.AddWithValue("@order_udate", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@order_pdate", item.order_pdate);

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
        /// 발주현황 조회
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrderList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetOrderList";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();

                DataTable ds = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                da.Dispose();

                cmd.Connection.Close();
                return ds;
            }
        }

        /// <summary>
        /// 발주 취소(delete)
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool UpdateOrder(List<OrderVO> list)
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

                    foreach (OrderVO item in list)
                    {
                        cmd.Parameters.Clear();

                        cmd.CommandText = @"update TBL_ORDER set order_count = order_count - @order_count, order_udate = @order_udate where order_id = @order_id and plan_id = @plan_id";

                        cmd.Parameters.AddWithValue("@order_id", item.order_id);
                        cmd.Parameters.AddWithValue("@order_count", item.order_count);
                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
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

        /// <summary>
        /// 납기일 변경
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>

        public bool UpdateOrderDate(OrderVO vo)
        { 
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update TBL_ORDER set order_pdate = @order_pdate where order_id = @order_id and plan_id = @plan_id";

                cmd.Parameters.AddWithValue("@order_pdate", vo.order_pdate);
                cmd.Parameters.AddWithValue("@order_id", vo.order_id);
                cmd.Parameters.AddWithValue("@plan_id", vo.plan_id);

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }
    }
}
