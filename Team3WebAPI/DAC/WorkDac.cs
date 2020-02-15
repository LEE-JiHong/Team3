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
using Team3WebAPI;


namespace Team3WebAPI
{
    public class WorkDac : ConnectionAccess
    {
      
        public List<WorkRatePlanVO> GetWorkRatePlan()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select convert(int,ROW_NUMBER() OVER(ORDER BY so.plan_id)) row, so.plan_id plan_id,so.product_name product_name,so.company_code company_code,so.so_pcount so_pcount,pp.pro_count pro_count,  left((pp.pro_count*1.0/so_pcount*1.0 * 100),5) rate from (select plan_id,product_name,company_code,sum(so_pcount) so_pcount from TBL_SO_MASTER where so_edate>getdate() group by plan_id,product_name,company_code) so inner join(select plan_id, sum(pro_count) pro_count from TBL_PRODUCTION_PLAN where pro_state = 'COMPLETE' group by plan_id) pp on so.plan_id = pp.plan_id";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<WorkRatePlanVO> list = Helper.DataReaderMapToList<WorkRatePlanVO>(reader);
                
                cmd.Connection.Close();
                return list;

            }
        }
    }
}