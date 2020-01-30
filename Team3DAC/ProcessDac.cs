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
    public class ProcessDac : ConnectionAccess
    {
        public DataTable GetProductionPlanCheck(string startDate, string EndDate)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetProductionPlanCheck";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate); 
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection.Close();
                DataTable table = new DataTable();
                da.Fill(table);
                 
                return table;
            }
        }
    }
}
