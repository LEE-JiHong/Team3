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
    class OrderDac :ConnectionAccess
    {
        /// <summary>
        /// 업로드한 영업마스터를 기준으로 영업마스터 생성(insert)
        /// </summary>
        /// <param name="VO"></param>
        /// <returns></returns>
        public bool AddSOMaster(SOMasterVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "insert into TBL_SO_MASTER(plan_id, so_wo_id, company_code, company_type, product_name, so_pcount, so_edate, so_sdate) " +
                    "values(@plan_id, @so_wo_id, @company_code, @company_type, @product_name, @so_pcount, @so_edate, @so_sdate)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@plan_id", vo.plan_id);
                cmd.Parameters.AddWithValue("@so_wo_id", vo.so_wo_id);
                cmd.Parameters.AddWithValue("@company_code", vo.company_code);
                cmd.Parameters.AddWithValue("@company_type", vo.company_type);
                cmd.Parameters.AddWithValue("@product_name", vo.product_name);
                cmd.Parameters.AddWithValue("@so_pcount", vo.so_pcount);
                cmd.Parameters.AddWithValue("@so_edate", vo.so_edate);
                cmd.Parameters.AddWithValue("@so_sdate", vo.so_sdate);

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }
    }
}
