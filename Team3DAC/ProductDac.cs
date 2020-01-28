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
        /// <summary>
        /// 품목 추가
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool AddProduct(ProductVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "AddProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@product_name", VO.product_name);
                cmd.Parameters.AddWithValue("@product_codename", VO.product_codename);
                cmd.Parameters.AddWithValue("@product_unit", VO.product_unit);
                cmd.Parameters.AddWithValue("@product_unit_count", VO.product_unit_count);
                cmd.Parameters.AddWithValue("@product_type", VO.product_type);
                cmd.Parameters.AddWithValue("@product_in_sector", VO.product_in_sector);
                cmd.Parameters.AddWithValue("@product_out", VO.product_out);
                cmd.Parameters.AddWithValue("@product_leadtime", VO.product_leadtime);
                cmd.Parameters.AddWithValue("@product_lorder_count", VO.product_lorder_count);
                cmd.Parameters.AddWithValue("@product_safety_count", VO.product_safety_count);
                cmd.Parameters.AddWithValue("@product_admin", VO.product_admin);
                cmd.Parameters.AddWithValue("@product_ordertype", VO.product_ordertype);
                cmd.Parameters.AddWithValue("@product_yn", VO.product_yn);
                cmd.Parameters.AddWithValue("@product_supply_com", VO.product_supply_com);
                cmd.Parameters.AddWithValue("@product_demand_com", VO.product_demand_com);
                cmd.Parameters.AddWithValue("@product_uadmin", VO.product_uadmin);
                cmd.Parameters.AddWithValue("@product_udate", VO.product_udate);
                cmd.Parameters.AddWithValue("@product_comment", VO.product_comment);
                cmd.Parameters.AddWithValue("@product_itemcode", VO.product_itemcode);
                cmd.Parameters.AddWithValue("@product_code", VO.product_code);
                cmd.Parameters.AddWithValue("@product_lsl", VO.product_lsl);
                cmd.Parameters.AddWithValue("@product_usl", VO.product_usl);
                cmd.Parameters.AddWithValue("@product_meastype", VO.product_meastype);


                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
            
        }

        /// <summary>
        /// 품목수정
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool UpdateProduct(ProductVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "UpdateProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@product_id", VO.product_id);
                cmd.Parameters.AddWithValue("@product_codename", VO.product_codename);
                cmd.Parameters.AddWithValue("@product_name", VO.product_name);
                cmd.Parameters.AddWithValue("@product_unit", VO.product_unit);
                cmd.Parameters.AddWithValue("@product_unit_count", VO.product_unit_count);
                cmd.Parameters.AddWithValue("@product_type", VO.product_type);
                cmd.Parameters.AddWithValue("@product_in_sector", VO.product_in_sector);
                cmd.Parameters.AddWithValue("@product_out", VO.product_out);
                cmd.Parameters.AddWithValue("@product_leadtime", VO.product_leadtime);
                cmd.Parameters.AddWithValue("@product_lorder_count", VO.product_lorder_count);
                cmd.Parameters.AddWithValue("@product_safety_count", VO.product_safety_count);
                cmd.Parameters.AddWithValue("@product_admin", VO.product_admin);
                cmd.Parameters.AddWithValue("@product_ordertype", VO.product_ordertype);
                cmd.Parameters.AddWithValue("@product_yn", VO.product_yn);
                cmd.Parameters.AddWithValue("@product_supply_com", VO.product_supply_com);
                cmd.Parameters.AddWithValue("@product_demand_com", VO.product_demand_com);
                cmd.Parameters.AddWithValue("@product_uadmin", VO.product_uadmin);
                cmd.Parameters.AddWithValue("@product_udate", VO.product_udate);
                cmd.Parameters.AddWithValue("@product_comment", VO.product_comment);
                cmd.Parameters.AddWithValue("@product_itemcode", VO.product_itemcode);
                cmd.Parameters.AddWithValue("@product_code", VO.product_code);
                cmd.Parameters.AddWithValue("@product_lsl", VO.product_lsl);
                cmd.Parameters.AddWithValue("@product_usl", VO.product_usl);
                cmd.Parameters.AddWithValue("@product_meastype", VO.product_meastype);


                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }

        }

        public List<UserVO> GetUserAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select * from TBL_USER";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<UserVO> list = Helper.DataReaderMapToList<UserVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
    }
}