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
    public class ProductDac : ConnectionAccess
    {
        public List<ProductVO> GetProductsAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetProductsAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProductVO> list = Helper.DataReaderMapToList<ProductVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
    }
}