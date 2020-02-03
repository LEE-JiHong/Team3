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
    public class PurchasingDAC : ConnectionAccess
    {
        public DataSet GetOrderList(string planID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetOrder";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@plan_id", planID);

                cmd.Connection.Open();
                //SqlDataReader reader = cmd.ExecuteReader();

                //List<DayVO> list = Helper.DataReaderMapToList<DayVO>(reader);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                da.Dispose();

                cmd.Connection.Close();
                return ds;
            }
        }

        public bool InsertOrder(List<OrderVO> list)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                SqlTransaction tran = cmd.Connection.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.Text;

                    foreach (OrderVO item in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@company_name", item.company_name);

                        cmd.CommandText = @"select company_order_code from TBL_COMPANY where company_name = @company_name";

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            item.order_id = reader["company_order_code"].ToString();
                        }
                        reader.Close();

                        cmd.CommandText = @"insert into TBL_SO_MASTER(plan_id, so_wo_id, company_code, company_type, product_name, so_pcount, so_edate, so_sdate, so_ocount, so_ccount) " +
                    "values(@plan_id, @so_wo_id, @company_code, @company_type, @product_name, @so_pcount, @so_edate, @so_sdate, 0, 0)";

                        //cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        //cmd.Parameters.AddWithValue("@so_wo_id", item.so_wo_id);
                        //cmd.Parameters.AddWithValue("@company_type", item.company_type);
                        //cmd.Parameters.AddWithValue("@product_name", item.product_name);
                        //cmd.Parameters.AddWithValue("@so_pcount", item.so_pcount);
                        //cmd.Parameters.AddWithValue("@so_edate", item.so_edate);
                        //cmd.Parameters.AddWithValue("@so_sdate", item.so_sdate);
                        //cmd.ExecuteNonQuery();
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
