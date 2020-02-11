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
    public class SupplierDAC : ConnectionAccess
    {
        /// <summary>
        /// order_state가 발주상태인 목록 가져오기
        /// </summary>
        /// <returns></returns>
        public DataTable GetAlreadyOrderList(SupplierVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                 sql.Append($"select order_serial, concat(LEFT(order_serial, 4),'-',SUBSTRING(order_serial, 5,2),'-',SUBSTRING(order_serial, 7,2)) as order_ddate, c.company_name, p.product_codename, product_name, o.order_count, o.order_pdate, cc.common_name from TBL_ORDER o inner join TBL_PRODUCT p on o.product_id = p.product_id inner join TBL_COMPANY c on p.product_demand_com = c.company_code inner join TBL_COMMON_CODE cc on o.order_state = cc.common_value where o.order_state = @order_state and CONVERT (DATETIME, o.order_pdate) >= CONVERT (DATETIME, @startDate) and CONVERT (DATETIME, o.order_pdate) <= CONVERT (DATETIME, @endDate)");

                if (vo.company_name != null)
                {
                    sql.Append(" and company_name = @company_name");
                    cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                }

                if (vo.order_id != null)
                {
                    sql.Append($" and order_id like '%{vo.order_id}%'");
                   // cmd.Parameters.AddWithValue("@order_id", vo.order_id);
                }

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@order_state", vo.order_state);
                cmd.Parameters.AddWithValue("@startDate", vo.start_date);
                cmd.Parameters.AddWithValue("@endDate", vo.end_date);

                DataTable dataTable = new DataTable();

                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
                da.Dispose();

                cmd.Connection.Close();
                return dataTable;
            }
        }

        public bool UpdateOrderState(List<WatingReceivingVO> list)
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

                    foreach (WatingReceivingVO item in list)
                    {
                        cmd.Parameters.Clear();

                        cmd.CommandText = @"update TBL_ORDER set order_state = 'P_WAIT', order_pdate = @order_pdate, order_sdate = @order_sdate where order_serial = @order_id";

                        cmd.Parameters.AddWithValue("@order_id", item.order_id);
                        cmd.Parameters.AddWithValue("@order_pdate", item.order_pdate);
                        cmd.Parameters.AddWithValue("@order_sdate", item.order_sdate);

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
