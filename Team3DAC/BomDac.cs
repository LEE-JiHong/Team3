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
        /// <summary>
        /// 모든 Bom 조회
        /// </summary>
        /// <returns></returns>
        public List<BomVO> GetBomAll(string bom_id = null,string product_id=null)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetBomAll";
                if (bom_id == null && product_id ==null)
                { 
                    cmd.Parameters.AddWithValue("@bom_id", DBNull.Value);
                    cmd.Parameters.AddWithValue("@product_id", DBNull.Value);
                }
                else if (bom_id == null && product_id!=null)
                {
                    cmd.Parameters.AddWithValue("@bom_id", DBNull.Value);
                    cmd.Parameters.AddWithValue("@product_id", product_id);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@bom_id", Convert.ToInt32(bom_id));
                    cmd.Parameters.AddWithValue("@product_id", DBNull.Value);
                }
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
        public int GetProductTypeNum(int product_id)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                int pType_num = 0;
                string sql = "GetProductTypeNum";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@product_id", product_id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pType_num = Convert.ToInt32(reader[0]);
                }

                cmd.Connection.Close();
                return pType_num;
            }
        }
        public bool AddBom(BomVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "AddBom";
                cmd.CommandType = CommandType.StoredProcedure;

                if (VO.bom_parent_id == null)
                {
                    cmd.Parameters.AddWithValue("@bom_parent_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@bom_parent_id", VO.bom_parent_id); 
                }
                cmd.Parameters.AddWithValue("@product_id", VO.product_id);
                cmd.Parameters.AddWithValue("@bom_use_count", VO.bom_use_count);
                cmd.Parameters.AddWithValue("@bom_sdate", VO.bom_sdate);
                cmd.Parameters.AddWithValue("@bom_edate", VO.bom_edate);
                cmd.Parameters.AddWithValue("@bom_yn", VO.bom_yn);
                cmd.Parameters.AddWithValue("@plan_yn", VO.plan_yn);
                cmd.Parameters.AddWithValue("@bom_comment", VO.bom_comment);
                cmd.Parameters.AddWithValue("@bom_uadmin", VO.bom_uadmin);
                cmd.Parameters.AddWithValue("@bom_udate", VO.bom_udate);

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }

        }
        public bool UpdateBOM(BomVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "UpdateBOM";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@bom_id", VO.bom_id);
                cmd.Parameters.AddWithValue("@bom_parent_id", VO.bom_parent_id);
                cmd.Parameters.AddWithValue("@product_id", VO.product_id);
                cmd.Parameters.AddWithValue("@bom_use_count", VO.bom_use_count);
                cmd.Parameters.AddWithValue("@bom_sdate", VO.bom_sdate);
                cmd.Parameters.AddWithValue("@bom_edate", VO.bom_edate);
                cmd.Parameters.AddWithValue("@bom_yn", VO.bom_yn);
                cmd.Parameters.AddWithValue("@plan_yn", VO.plan_yn);
                cmd.Parameters.AddWithValue("@bom_comment", VO.bom_comment);
                cmd.Parameters.AddWithValue("@bom_uadmin", VO.bom_uadmin);
                cmd.Parameters.AddWithValue("@bom_udate", VO.bom_udate);


                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }

        }

    }
}
