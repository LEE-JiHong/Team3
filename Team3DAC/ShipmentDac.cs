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

    }
}
