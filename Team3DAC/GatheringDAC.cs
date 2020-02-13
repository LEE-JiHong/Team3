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
    public class GatheringDAC : ConnectionAccess
    {

        public bool InsertGatheringData(string[] list)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "InsertGatheringUJOINT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@datetime", list[0]);
                cmd.Parameters.AddWithValue("@barcode", list[1]);
                cmd.Parameters.AddWithValue("@code", list[2]);

                cmd.Parameters.AddWithValue("@okng", list[3]);
                cmd.Parameters.AddWithValue("@data11", list[4]);
                cmd.Parameters.AddWithValue("@data12", list[5]);
                cmd.Parameters.AddWithValue("@data21", list[6]);
                cmd.Parameters.AddWithValue("@data31", list[7]);


                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();


            }

            return true;

        }
    }
}
