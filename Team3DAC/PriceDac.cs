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
    public class PriceDac : ConnectionAccess
    {
        public List<PriceInfoVO> GetPriceInfo(string company_type)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetPriceInfo";
                if (company_type != null)
                {
                    cmd.Parameters.AddWithValue("@company_type", company_type);
                }
                else if (company_type == null)
                {
                    cmd.Parameters.AddWithValue("@company_type", DBNull.Value);
                }

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<PriceInfoVO> list = Helper.DataReaderMapToList<PriceInfoVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        public bool AddPriceInfo(PriceInfoVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "AddPriceInfo";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@product_id", VO.product_id);
                cmd.Parameters.AddWithValue("@company_id", VO.company_id);
                cmd.Parameters.AddWithValue("@price_present", VO.price_present);
                cmd.Parameters.AddWithValue("@price_past", VO.price_past);
                cmd.Parameters.AddWithValue("@price_sdate", VO.price_sdate);
                cmd.Parameters.AddWithValue("@price_edate", VO.price_edate);
                cmd.Parameters.AddWithValue("@price_yn", VO.price_yn);
                cmd.Parameters.AddWithValue("@price_uadmin", VO.price_uadmin);
                cmd.Parameters.AddWithValue("@price_udate", VO.price_udate);
                cmd.Parameters.AddWithValue("@price_comment", VO.price_comment);

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }

        }

        public bool UpdatePriceInfo(PriceInfoVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "UpdatePriceInfo";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@price_id", VO.price_id);
                cmd.Parameters.AddWithValue("@product_id", VO.product_id);
                cmd.Parameters.AddWithValue("@company_id", VO.company_id);
                cmd.Parameters.AddWithValue("@price_present", VO.price_present);
                cmd.Parameters.AddWithValue("@price_past", VO.price_past);
                cmd.Parameters.AddWithValue("@price_sdate", VO.price_sdate);
                cmd.Parameters.AddWithValue("@price_edate", VO.price_edate);
                cmd.Parameters.AddWithValue("@price_yn", VO.price_yn);
                cmd.Parameters.AddWithValue("@price_uadmin", VO.price_uadmin);
                cmd.Parameters.AddWithValue("@price_udate", VO.price_udate);
                cmd.Parameters.AddWithValue("@price_comment", VO.price_comment);

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }

        }
    }
}
