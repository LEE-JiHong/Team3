﻿using System;
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
                string sql = "select convert(int,ROW_NUMBER() OVER(ORDER BY so.plan_id)) row,so.plan_id plan_id, so.product_name product_name, so.company_code company_code, so.so_pcount so_pcount, ISNULL(pp.pro_count, 0) pro_count,ISNULL(left((pp.pro_count * 1.0 / so_pcount * 1.0 * 100), 5), '0') rate from(select plan_id, product_name, company_code, sum(so_pcount) so_pcount from TBL_SO_MASTER where so_edate> getdate() group by plan_id,product_name,company_code) so LEFT join(select plan_id, sum(pro_count) pro_count from TBL_PRODUCTION_PLAN where pro_state = 'FINISH' group by plan_id) pp on so.plan_id = pp.plan_id";
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

        public List<WorkChartVO> GetWorkTimeRank()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select pd.worker_id,u.user_name,sum(worktime) time from (select * from TBL_PRODUCTION_PLAN where year(pro_date)=year(getdate())) pp inner join TBL_PRODUCTION_PLAN_DETAIL pd on pp.pro_id = pd.pro_id inner join TBL_USER u on pd.worker_id = u.user_id group by pd.worker_id,u.user_name order by time desc";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<WorkChartVO> list = Helper.DataReaderMapToList<WorkChartVO>(reader);

                cmd.Connection.Close();
                return list;

            }
        }
            public List<TodayUnWorkingVO> GetTodayUnWorkingTimeData()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "select top 5 m.m_id, wt.w_edate,m.m_name,wt.w_category,wt.w_comment,convert(int,w_time/60) min from TBL_WORKING_TIME wt inner join TBL_MACHINE m on wt.w_machine = m.m_id where convert(char(10),w_edate,23) = convert(char(10),getdate(),23) order by w_edate desc";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<TodayUnWorkingVO> list = Helper.DataReaderMapToList<TodayUnWorkingVO>(reader);

                cmd.Connection.Close();
                return list;

            }
        }

        public List<UnWorkingTimeRank> GetUnWorkingTimeData()
        {
           
             using (SqlCommand cmd = new SqlCommand())
            {
                //string sql = "select top 3 convert(int,ROW_NUMBER() OVER(ORDER BY convert(int, sum(w_time) / 60000) desc)) row,w_comment, convert(int, sum(w_time) / 60000) w_time , convert(int,(select sum(w_time) from TBL_WORKING_TIME )/60000) total from TBL_WORKING_TIME group by w_comment";
                string sql = "select top 3 convert(int,ROW_NUMBER() OVER(ORDER BY convert(int, sum(w_time) / 60) desc)) row,w_comment, convert(int, sum(w_time) / 60) w_time ,count(w_comment) total from TBL_WORKING_TIME group by w_comment order by total desc";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<UnWorkingTimeRank> list = Helper.DataReaderMapToList<UnWorkingTimeRank>(reader);

                cmd.Connection.Close();
                return list;

            }
        }

        public List<TodayWorkRateVO> GetTodayWorkRate()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
               
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "WebGetWorkName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<TodayWorkRateVO> list = Helper.DataReaderMapToList<TodayWorkRateVO>(reader);

                cmd.Connection.Close();
                return list;

            }
        }
    }
}