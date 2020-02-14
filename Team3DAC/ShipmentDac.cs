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

        /// <summary>
        /// 이동수량 개수만큼 이동처리
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool TransferProcessing(List<ShipmentVO> list)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "TransferProcessing";
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@plan_id", VO.plan_id);
                //cmd.Parameters.AddWithValue("@factory_name", VO.factory_name);
                //cmd.Parameters.AddWithValue("@product_id", VO.product_id);
                //cmd.Parameters.AddWithValue("@w_count_present", VO.w_count_present);
                //cmd.Parameters.AddWithValue("@wh_uadmin", VO.uadmin);//TODO : admin -> 실제 수정자
                //if(VO.wh_comment == null)
                //{
                //    cmd.Parameters.AddWithValue("@wh_comment", "");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@wh_comment", VO.wh_comment);
                //}
                //cmd.Parameters.AddWithValue("@wh_category", VO.category);
                //cmd.Parameters.AddWithValue("@wh_udate", DateTime.Now.ToString("yyyy-MM-dd"));
                

                

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }

        }


    }
}
