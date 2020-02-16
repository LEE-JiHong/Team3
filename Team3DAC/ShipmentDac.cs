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
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "TransferProcessing";
                    //int num = 1;

                    foreach (var item in list)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@factory_name", item.factory_name);
                        cmd.Parameters.AddWithValue("@product_id", item.product_id);
                        cmd.Parameters.AddWithValue("@w_count_present", item.w_count_present);
                        cmd.Parameters.AddWithValue("@wh_uadmin", item.uadmin);//TODO : admin -> 실제 수정자
                        if (item.wh_comment == null)
                        {
                            cmd.Parameters.AddWithValue("@wh_comment", "");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@wh_comment", item.wh_comment);
                        }
                        cmd.Parameters.AddWithValue("@wh_category", item.category);
                        cmd.Parameters.AddWithValue("@wh_udate", DateTime.Now.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    cmd.Connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    tran.Rollback();
                    cmd.Connection.Close();
                    return false;
                }
            }
        }
    }
}

