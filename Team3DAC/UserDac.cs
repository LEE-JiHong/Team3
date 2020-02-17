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
    public class UserDac : ConnectionAccess
    {
        public int LoginCheck(string id, string pwd)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "select count(*) from TBL_USER where user_id = @user_id and user_pwd = @user_pwd";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@user_id", id);
                cmd.Parameters.AddWithValue("@user_pwd", pwd);

                cmd.Connection.Open();

                int rowCount = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Connection.Close();
                return rowCount;
            }
        }

    }
}
