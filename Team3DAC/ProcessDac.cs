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
    public class ProcessDac : ConnectionAccess
    {
        public DataTable GetProductionPlanCheck(string startDate, string EndDate)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetProductionPlanCheck";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection.Close();
                DataTable table = new DataTable();
                da.Fill(table);

                return table;
            }
        }
        public bool UpdateCommand(int num, string tdate)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "UpdateCommand";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", num);
                cmd.Parameters.AddWithValue("@pro_date", tdate);
                cmd.Connection.Open();

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }
        public DataTable GetProductionPlanCheckHis(string startDate, string EndDate, string state = "CREATE")
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "GetProductionPlanCheckHis";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@State", state);
                DataTable table = new DataTable();
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                da.Dispose();
                cmd.Connection.Close();

                return table;
            }
        }
        public DataTable GetProductFromBOM(string i)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "GetProductFromBOM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parentid", i);


                DataTable table = new DataTable();
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(table);
                da.Dispose();
                List<int> productID = new List<int>();
                for (int k = 0; table.Rows.Count > k; k++)
                {
                    productID.Add(Convert.ToInt32(table.Rows[k][0].ToString()));
                }
                cmd.Connection.Close();

                return table;
            }
        }
        public List<DMRVO> GetDMRMgt(DMRVO vo)
        {

            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);

                cmd.CommandText = "GetDMRMgt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@plan_id", vo.plan_id);
                cmd.Parameters.AddWithValue("@pro_id", vo.pro_id);
                cmd.Parameters.AddWithValue("@WH", vo.factory_name);
                cmd.Parameters.AddWithValue("@product_codename", vo.product_codename);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<DMRVO> list = Helper.DataReaderMapToList<DMRVO>(reader);
                cmd.Connection.Close();
                return list;


            }
        }
        public DataTable GetDMR_dt(DMRVO vo)
        {

            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);

                cmd.CommandText = "GetDMRMgt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@plan_id", vo.plan_id);
                cmd.Parameters.AddWithValue("@pro_id", vo.pro_id);
                cmd.Parameters.AddWithValue("@WH", vo.factory_name);
                cmd.Parameters.AddWithValue("@product_codename", vo.product_codename);
                cmd.Connection.Open();
                DataTable table = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                da.Dispose();
                cmd.Connection.Close();

                return table;


            }
        }
        public bool tranWH(List<DMRVO> lst)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                try
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    SqlTransaction tran = cmd.Connection.BeginTransaction();
                    string sql_1 = @"update TBL_WAREHOUSE set w_count_present = w_count_present - @req_count  
                                        where plan_id = @plan_id  and factory_id = @req_factory_id  and product_id = @product_id; 
                                     insert into TBL_WAREHOUSE_HIS(w_id,pro_id,  product_id, wh_product_count,   wh_udate, wh_comment, wh_category) 
                                                                            values(@w_id,@pro_id, @product_id, @req_count,     @req_date,    @reason, 'P_MOVE_ITEM')";
                    ;

                    cmd.Transaction = tran;
                    cmd.CommandText = sql_1;
                    //뺴는작업
                    for (int i = 0; i < lst.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pro_id", lst[i].pro_id);
                        cmd.Parameters.AddWithValue("@req_factory_id", lst[i].req_factory_id);
                        cmd.Parameters.AddWithValue("@plan_id", lst[i].plan_id);
                        cmd.Parameters.AddWithValue("@product_id", lst[i].product_id);
                        cmd.Parameters.AddWithValue("@req_count", lst[i].req_count);
                        cmd.Parameters.AddWithValue("@w_id", lst[i].w_id);
                        cmd.Parameters.AddWithValue("@req_date", lst[i].req_date);
                        if (lst[i].reason == null)
                        {
                            SqlParameter reason = new SqlParameter("@reason", SqlDbType.VarChar);
                            reason.Value = DBNull.Value;
                            cmd.Parameters.Add(reason);
                        }
                        else
                            cmd.Parameters.AddWithValue("@reason", lst[i].reason);
                        // cmd.Parameters.AddWithValue("@reason", lst[i].reason);
                        //       cmd.Parameters.AddWithValue("@order_id", lst[i].order_id);

                        cmd.ExecuteNonQuery();
                    }

                    sql_1 = "FrodMove";
                    cmd.CommandText = sql_1;
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < lst.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pro_id", lst[i].pro_id);
                        cmd.Parameters.AddWithValue("@factory_id", lst[i].factory_id);
                        cmd.Parameters.AddWithValue("@plan_id", lst[i].plan_id);
                        cmd.Parameters.AddWithValue("@product_id", lst[i].product_id);
                        cmd.Parameters.AddWithValue("@req_count", lst[i].req_count);
                        cmd.Parameters.AddWithValue("@w_id", lst[i].w_id);
                        cmd.Parameters.AddWithValue("@req_date", lst[i].req_date);
                        if (lst[i].reason == null)
                        {
                            SqlParameter reason = new SqlParameter("@reason", SqlDbType.VarChar);
                            reason.Value = DBNull.Value;
                            cmd.Parameters.Add(reason);
                        }
                        else
                            cmd.Parameters.AddWithValue("@reason", lst[i].reason);
                        //     cmd.Parameters.AddWithValue("@order_id", lst[i].order_id);

                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    cmd.Connection.Close();

                    return true;

                }
                catch (Exception err)
                {
                    string st = err.Message;
                    return false;
                }
            }
        }
        public List<WorkRecode_VO> WorkRecode()
        {

            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                cmd.CommandText = "WorkRecode";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                List<WorkRecode_VO> list = Helper.DataReaderMapToList<WorkRecode_VO>(reader);
                cmd.Connection.Close();
                return list;


            }
        }
        public bool FinishRecode(List<DMRVO> lst, List<WorkRecode_VO> w_lst)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    SqlTransaction tran = cmd.Connection.BeginTransaction();
                    string sql_1 = @"update TBL_PRODUCTION_PLAN set pro_state='FINISH'  where pro_id=(select pro_id from TBL_PRODUCTION_PLAN where pro_state='COMPLETE');
                                        update TBL_WAREHOUSE set w_count_present = w_count_present - @req_count  
                                        where plan_id = @plan_id  and factory_id = @req_factory_id  and product_id = @product_id;
                                        insert into tbl_warehouse_his(w_id,pro_id, product_id, wh_product_count, wh_udate, wh_comment, wh_category)
                                        values(@w_id,@pro_id, @product_id, @req_count, @req_date, @reason, 'P_PRODUCTION')";


                    cmd.Transaction = tran;
                    cmd.CommandText = sql_1;
                    //뺴는작업
                    for (int i = 0; i < lst.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@req_count", lst[i].plan_count);
                        cmd.Parameters.AddWithValue("@plan_id", lst[i].plan_id);
                        cmd.Parameters.AddWithValue("@product_id", lst[i].product_id);
                        cmd.Parameters.AddWithValue("@req_factory_id", w_lst[0].m_use_sector_id);
                        cmd.Parameters.AddWithValue("@w_id", lst[i].w_id);
                        cmd.Parameters.AddWithValue("@pro_id", lst[i].pro_id);
                        cmd.Parameters.AddWithValue("@req_date", DateTime.Now.ToShortDateString());

                        if (lst[i].reason == null)
                        {
                            SqlParameter reason = new SqlParameter("@reason", SqlDbType.VarChar);
                            reason.Value = DBNull.Value;
                            cmd.Parameters.Add(reason);
                        }
                        else
                            cmd.Parameters.AddWithValue("@reason", "생산실적등록");
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                    sql_1 = "FrodMove2 ";
                    cmd.CommandText = sql_1;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@factory_id", lst[0].factory_id);
                    cmd.Parameters.AddWithValue("@plan_id", w_lst[0].plan_id);
                    cmd.Parameters.AddWithValue("@product_id", w_lst[0].product_id);
                    cmd.Parameters.AddWithValue("@pro_id", w_lst[0].pro_id);
                    cmd.Parameters.AddWithValue("@req_count", w_lst[0].pro_count);
                    cmd.Parameters.AddWithValue("@req_date", DateTime.Now.ToShortDateString());
                    if (w_lst[0].reason == null)
                    {
                        SqlParameter reason = new SqlParameter("@reason", SqlDbType.VarChar);
                        reason.Value = DBNull.Value;
                        cmd.Parameters.Add(reason);
                    }
                    else
                        cmd.Parameters.AddWithValue("@reason", "생산실적등록");

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.CommandText = "InsertRecode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@worknum", w_lst[0].worknum);
                    cmd.Parameters.AddWithValue("@pro_id", w_lst[0].pro_id);
                    cmd.Parameters.AddWithValue("@pro_date", w_lst[0].pro_date);
                    cmd.Parameters.AddWithValue("@pd_stime", w_lst[0].pd_stime);
                    cmd.Parameters.AddWithValue("@pd_etime", w_lst[0].pd_etime);
                    cmd.Parameters.AddWithValue("@product_id", w_lst[0].product_id);
                    cmd.Parameters.AddWithValue("@product_name", w_lst[0].product_name);
                    cmd.Parameters.AddWithValue("@pro_state", w_lst[0].pro_state);
                    cmd.Parameters.AddWithValue("@common_name", w_lst[0].common_name);
                    cmd.Parameters.AddWithValue("@worktime", w_lst[0].worktime);
                    cmd.Parameters.AddWithValue("@pro_count", w_lst[0].pro_count);
                    cmd.Parameters.AddWithValue("@ok_cnt", w_lst[0].ok_cnt);
                    cmd.Parameters.AddWithValue("@ng_cnt", w_lst[0].ng_cnt);
                    cmd.Parameters.AddWithValue("@m_name", w_lst[0].m_name);
                    cmd.Parameters.AddWithValue("@m_id", w_lst[0].m_id);
                    cmd.ExecuteNonQuery();

                    tran.Commit();
                    cmd.Connection.Close();
                    return true;

                }
                catch (Exception err)
                {
                    string st = err.Message;
                    return false;
                }
            }
        }
        public List<WorkRecode_VO> GetWork()
        {

            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.Connection.Open();
                cmd.CommandText = @"select pro_date, worknum ,worktime,w.product_id,p.product_codename product_codename,p.product_name product_name, m_name, pd_stime,pd_etime,ok_cnt,ng_cnt, c.common_name as pro_state
                                                from TBL_WORK_RECODE w inner join TBL_PRODUCT p on w.product_id = p.product_id  inner join TBL_COMMON_CODE c on w.pro_state = c.common_value";
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                List<WorkRecode_VO> list = Helper.DataReaderMapToList<WorkRecode_VO>(reader);
                cmd.Connection.Close();
                return list;


            }
        }
    }
}