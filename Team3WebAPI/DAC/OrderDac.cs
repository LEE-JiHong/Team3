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
       

        public List<LastestOrderVO> GetLastestOrderList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT TOP 5 wh_udate,order_id,wh_comment,wh_product_count  FROM TBL_WAREHOUSE_HIS WHERE wh_category ='P_ORDER_IN' ORDER BY wh_udate DESC";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<LastestOrderVO> list = Helper.DataReaderMapToList<LastestOrderVO>(reader);
                reader.Close();
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesChartVO> GetYearSalesCompanyList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT  sum(s_TotalPrice) totalprice,s_company  FROM TBL_SALES_COMPLETE where CONVERT(CHAR(7), s_date,23) between CONVERT(CHAR(7),(select DATEADD(YYYY, -1, getdate())),23)  AND CONVERT(CHAR(7),(select DATEADD(YYYY, 0, getdate())),23) GROUP BY s_company order by totalprice desc";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesChartVO> list = Helper.DataReaderMapToList<SalesChartVO>(reader);
                reader.Close();
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesChartVO> GetYearSalesChartList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT CONVERT(CHAR(7), s_date,23) s_month,SUM(S_COUNT) s_count,SUM(s_TotalPrice) totalprice FROM TBL_SALES_COMPLETE where CONVERT(CHAR(7), s_date,23) between CONVERT(CHAR(7),(select DATEADD(YYYY, -1, getdate())),23)  AND CONVERT(CHAR(7),(select DATEADD(MM, -1, getdate())),23)  GROUP BY CONVERT(CHAR(7), s_date, 23) order by s_month";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesChartVO> list = Helper.DataReaderMapToList<SalesChartVO>(reader);
                reader.Close();
                cmd.Connection.Close();
                return list;
            }
        }

        public List<LastestOrderDataVO> GetLastestOrderDataList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select top 5 order_id,plan_id,p.product_name,order_count,order_state,order_sdate from TBL_ORDER o inner join TBL_PRODUCT p  on o.product_id = p.product_id order by order_sdate desc";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<LastestOrderDataVO> list = Helper.DataReaderMapToList<LastestOrderDataVO>(reader);
                reader.Close();
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesChartVO> GetOrderCostList()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "SELECT convert(nvarchar,month(order_sdate)) s_month ,sum(o.order_count* p.price_present) totalprice FROM TBL_ORDER o inner join  TBL_P_PRICE p on o.product_id = p.product_id WHERE YEAR(order_sdate) = YEAR(GETDATE()) group by month(order_sdate) having month(order_sdate) between month(DATEADD(MONTH,-1,GETDATE())) and month(getdate())";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesChartVO> list = Helper.DataReaderMapToList<SalesChartVO>(reader);
                reader.Close();
                cmd.Connection.Close();
                return list;
            }
        }
    }
}
