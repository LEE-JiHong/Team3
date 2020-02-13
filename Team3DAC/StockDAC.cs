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
    public class StockDAC : ConnectionAccess
    {
        
        /// <summary>
        /// 품목유형 가져오기
        /// </summary>
        /// <param name="company_type"></param>
        /// <returns></returns>
        public List<CommonVO> GetProductType(string product_type)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = $"select common_name, common_value from TBL_COMMON_CODE where common_type = '{product_type}'";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CommonVO> list = Helper.DataReaderMapToList<CommonVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public List<CommonVO> GetFactory(string factory)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = $"select common_name, common_value from TBL_COMMON_CODE where common_type = '{factory}'";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CommonVO> list = Helper.DataReaderMapToList<CommonVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public DataTable GetMaterialStockList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();
                    
                   sql.Append($"select w_id, plan_id, factory_code, factory_name, p.product_codename, product_name, w_count_present, common_name as product_type, w_count_past from TBL_WAREHOUSE w inner join TBL_FACTORY f on w.factory_id = f.factory_id inner join TBL_PRODUCT p on p.product_id = w.product_id inner join TBL_COMMON_CODE c on c.common_value = p.product_type where 1=1");



                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;

                DataTable dataTable = new DataTable();

                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
                da.Dispose();

                cmd.Connection.Close();
                return dataTable;
            }
        }
    }
}
