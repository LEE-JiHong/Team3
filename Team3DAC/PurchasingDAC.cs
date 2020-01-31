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
        public DataTable GetOrderList(string planID)
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

                DataTable dataTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
                da.Dispose();

                cmd.Connection.Close();
                return dataTable;
            }
        }
    }
}
