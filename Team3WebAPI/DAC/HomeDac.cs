using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;

namespace Team3WebAPI
{
    public class HomeDac : ConnectionAccess
    {

        public List<UserVO> GetLastestUsers()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select * from TBL_USER where Month(user_cdate) = Month(convert(char(10),getdate(),23))  and  year(user_cdate) = year(convert(char(10),getdate(),23))  ";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<UserVO> list = Helper.DataReaderMapToList<UserVO>(reader);
                reader.Close();
                cmd.Connection.Close();
                return list;
            }
        }

        public List<CompanyVO> GetCompanyCount()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select month(company_udate) month,count(company_id) sum from TBL_COMPANY group by Month(company_udate) having Month(company_udate) between(SELECT Month(DATEADD(month, -1, getdate()))) and Month(getdate())";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(reader);
                reader.Close();
                cmd.Connection.Close();
                return list;

            }
        }

        public List<WorkOrderVO> GetLastestOrderList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select top 5 so_edate,so.company_code,so_pcount,com.company_pic,so.product_name from TBL_SO_MASTER so inner join TBL_COMPANY com on so.company_code = com.company_code where so_edate> getdate() group by plan_id, so_edate,so.company_code,so_pcount,com.company_pic,product_name";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<WorkOrderVO> list = Helper.DataReaderMapToList<WorkOrderVO>(reader);
                reader.Close();
                cmd.Connection.Close();
                return list;

            }
        }

        public List<SalesVO> GetSalesRate()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select Month(s_date) month,sum(s_TotalPrice) price from TBL_SALES_COMPLETE where year(s_date) = year(getdate()) group by Month(s_date) having Month(s_date) between (SELECT Month(DATEADD(month, -1, getdate()))) and  (SELECT Month(getdate()))";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesVO> list = Helper.DataReaderMapToList<SalesVO>(reader);
                cmd.Connection.Close();
                return list;

            }
        }


        

        public WorkRateVO GetWorkRate()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"select  (SELECT DATENAME(DAY, DATEADD(DAY, -1, DATEADD(MONTH, 1, CONVERT(VARCHAR(6), GETDATE(), 112)+'01')))) totaldate,
((select count(pro_date) from TBL_PRODUCTION_PLAN where month(pro_date) = month(getdate()))) workdate,
left(((select count(pro_date) from TBL_PRODUCTION_PLAN where month(pro_date) = month(getdate()))*1.0 / (SELECT DATENAME(DAY, DATEADD(DAY, -1, DATEADD(MONTH, 1, CONVERT(VARCHAR(6), GETDATE(), 112) + '01'))))*1.0 ) *100,2) workrate";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<WorkRateVO> list = Helper.DataReaderMapToList<WorkRateVO>(reader);

                cmd.Connection.Close();
                return list[0];
            }
        }
    }
}
