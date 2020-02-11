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
    public class MaterialLedgerDAC : ConnectionAccess
    {
        /// <summary>
        /// 주문상태 리스트 가져오기
        /// </summary>
        /// <returns></returns>
        public List<OrderStateVO> GetOrderState()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                sql.Append($"select common_name as state_name, common_value as state_code from TBL_COMMON_CODE where common_type = 'material_order_state'");

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<OrderStateVO> list = Helper.DataReaderMapToList<OrderStateVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public DataTable GetWatingReceivingList(SupplierVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                sql.Append($"select order_serial, concat(LEFT(order_serial, 4),'-',SUBSTRING(order_serial, 5,2),'-',SUBSTRING(order_serial, 7,2)) as order_ddate, c.company_name, p.product_codename, product_name, o.order_count, o.order_pdate, cc.common_name, o.order_sdate from TBL_ORDER o inner join TBL_PRODUCT p on o.product_id = p.product_id inner join TBL_COMPANY c on p.product_demand_com = c.company_code inner join TBL_COMMON_CODE cc on o.order_state = cc.common_value where CONVERT (DATETIME, o.order_pdate) >= CONVERT (DATETIME, @startDate) and CONVERT (DATETIME, o.order_pdate) <= CONVERT (DATETIME, @endDate)");

                if (vo.company_name != null)
                {
                    sql.Append(" and company_name = @company_name");
                    cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                }

                if (vo.order_state != null)
                {
                    sql.Append($" and order_state = @order_state");
                    cmd.Parameters.AddWithValue("@order_state", vo.order_state);
                }

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;

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
    }
}
