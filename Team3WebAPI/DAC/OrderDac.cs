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



namespace Team3WebAPI
{
    public class OrderDac :ConnectionAccess
    {
        /// <summary>
        /// 업로드한 영업마스터를 기준으로 영업마스터 생성(insert)
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool AddSOMaster(List<SOMasterVO> list)
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

                    foreach (SOMasterVO item in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@company_code", item.company_code);

                        cmd.CommandText = @"select company_type from TBL_COMPANY where company_code = @company_code";

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            item.company_type = reader["company_type"].ToString();
                        }
                        reader.Close();

                        cmd.CommandText = @"insert into TBL_SO_MASTER(plan_id, so_od_id, so_wo_id, company_code, company_type, product_name, so_pcount, so_edate, so_sdate) " +
                    "values(@plan_id, @so_od_id, @so_wo_id, @company_code, @company_type, @product_name, @so_pcount, @so_edate, @so_sdate)";

                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@so_od_id", item.so_od_id);
                        cmd.Parameters.AddWithValue("@so_wo_id", item.so_wo_id);
                        cmd.Parameters.AddWithValue("@company_type", item.company_type);
                        cmd.Parameters.AddWithValue("@product_name", item.product_name);
                        cmd.Parameters.AddWithValue("@so_pcount", item.so_pcount);
                        cmd.Parameters.AddWithValue("@so_edate", item.so_edate);
                        cmd.Parameters.AddWithValue("@so_sdate", item.so_sdate);
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
