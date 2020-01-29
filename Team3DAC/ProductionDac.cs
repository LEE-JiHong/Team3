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
    public class ProductionDac : ConnectionAccess
    {
        public List<CommonVO> GetBomAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetBomAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CommonVO> list = Helper.DataReaderMapToList<CommonVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        public DataTable GetProductPlan(string planid, string startDate, string endDate)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetProductionPlan";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@plan_id", planid);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                 
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
