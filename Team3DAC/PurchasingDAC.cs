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
                string sql = "GetRealOrder";

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

        public int GetOrderSerialCount(string planID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select count(*) from TBL_ORDER where plan_id = @plan_id";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@plan_id", planID);

                cmd.Connection.Open();

                int resultNum = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Connection.Close();

                return resultNum;
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

                    //int num = 1;

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

                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.CommandText = @"select count(*) from TBL_ORDER where plan_id = @plan_id";

                        int resultNum = Convert.ToInt32(cmd.ExecuteScalar());

                        resultNum++;

                        item.order_serial = DateTime.Now.ToShortDateString().Replace("-", "") + string.Format("{0:D4}", resultNum);
                       // num++;

                        cmd.CommandText = @"insert into TBL_ORDER (order_id, product_id, order_count, plan_id, order_serial, order_state, order_udate, order_pdate, order_qcount, order_sdate) values (@order_id, @product_id, @order_count, @plan_id, @order_serial, 'O_COMPLETE', @order_udate, @order_pdate, @order_qcount, @order_sdate)";

                        cmd.Parameters.AddWithValue("@order_id", item.order_id);
                        cmd.Parameters.AddWithValue("@order_count", item.order_count);
                        cmd.Parameters.AddWithValue("@product_id", item.product_id);
                        cmd.Parameters.AddWithValue("@order_serial", item.order_serial);
                        cmd.Parameters.AddWithValue("@order_udate", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@order_pdate", item.order_pdate);
                        cmd.Parameters.AddWithValue("@order_qcount", item.order_count);
                        cmd.Parameters.AddWithValue("@order_sdate", DateTime.Now.ToShortDateString());

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
        public DataTable GetOrderList(SupplierVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("select order_serial, c.company_name, cc.common_name, p.product_codename, product_name, o.order_pdate, o.order_count, concat(LEFT(order_serial, 4),'-',SUBSTRING(order_serial, 5,2),'-',SUBSTRING(order_serial, 7,2)) as order_ddate,o.plan_id from TBL_ORDER o inner join TBL_PRODUCT p on o.product_id = p.product_id inner join TBL_COMPANY c on p.product_demand_com = c.company_code inner join TBL_COMMON_CODE cc on o.order_state = cc.common_value where o.order_state = 'O_COMPLETE' and CONVERT (DATETIME, o.order_pdate) >= CONVERT (DATETIME, @startDate) and CONVERT (DATETIME, o.order_pdate) <= CONVERT (DATETIME, @endDate)");

                if (vo.company_name != null)
                {
                    sql.Append(" and company_name = @company_name");
                    cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                }

                if (vo.order_id != null)
                {
                    sql.Append($" and order_serial like '%{vo.order_id}%'");
                    // cmd.Parameters.AddWithValue("@order_id", vo.order_id);
                }

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@startDate", vo.start_date);
                cmd.Parameters.AddWithValue("@endDate", vo.end_date);

                DataTable ds = new DataTable();

                cmd.Connection.Open();

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

                        cmd.CommandText = @"update TBL_ORDER set order_count = order_count - @order_count, order_udate = @order_udate, order_qcount = order_qcount - @order_qcount where order_serial = @order_serial and plan_id = @plan_id";

                        cmd.Parameters.AddWithValue("@order_id", item.order_id);
                        cmd.Parameters.AddWithValue("@order_count", item.order_count);
                        cmd.Parameters.AddWithValue("@order_qcount", item.order_count);
                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@order_udate", DateTime.Now.ToShortDateString());

                        cmd.CommandText = @"select order_count from TBL_ORDER where order_serial = @order_serial";

                        int order_count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (order_count <= 0)
                        {
                            cmd.CommandText = @"delete from TBL_ORDER where order_serial = @order_serial";
                        }

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
                cmd.CommandText = "update TBL_ORDER set order_pdate = @order_pdate where order_serial = @order_id and plan_id = @plan_id";

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
