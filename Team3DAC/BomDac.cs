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
    public class BomDac : ConnectionAccess
    {
        public List<BomVO> GetBomAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetBomAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<BomVO> list = Helper.DataReaderMapToList<BomVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
    }
}
