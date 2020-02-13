using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;

namespace Team3WebAPI
{
    public class HomeDac : ConnectionAccess
    {

        public List<UserVO> GetLastestUsers()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select * from TBL_USER where Month(user_cdate) = Month(convert(char(10),getdate(),23))  and  year(user_cdate) = year(convert(char(10),getdate(),23))  ";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<UserVO> list = Helper.DataReaderMapToList<UserVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }




    }
}
