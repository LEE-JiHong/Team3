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
        /// <summary>
        /// 모든 Product 조회
        /// </summary>
        /// <returns></returns>
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

        public bool AddProduct(ProductVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "AddMeterial";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@M_NAME", VO.PRODUCT_NAME);
               
            }
            return true;
                

        }
    }
}