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
                StringBuilder sb = new StringBuilder();
                try
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.Connection.Open();
                    SqlTransaction tran = cmd.Connection.BeginTransaction();
                    string sql_1 = @"update TBL_WAREHOUSE set w_count_present = w_count_present - @req_count  
                                        where plan_id = @plan_id  and factory_id = @req_factory_id  and product_id = @product_id; 
                                        insert into" ;

                    cmd.Transaction = tran;
                    cmd.CommandText = sql_1;
                    //뺴는작업
                    for (int i = 0; i < lst.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@req_factory_id", lst[i].req_factory_id);
                        cmd.Parameters.AddWithValue("@plan_id", lst[i].plan_id);
                        cmd.Parameters.AddWithValue("@product_id", lst[i].product_id);
                        cmd.Parameters.AddWithValue("@req_count", lst[i].req_count);
                        cmd.Parameters.AddWithValue("w_id", lst[i].reason);

                        cmd.ExecuteNonQuery();
                    }
                    
                    sql_1 = "FrodMove";
                    cmd.CommandText = sql_1;
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < lst.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@factory_id", lst[i].factory_id);
                        cmd.Parameters.AddWithValue("@plan_id", lst[i].plan_id);
                        cmd.Parameters.AddWithValue("@product_id", lst[i].product_id);
                        cmd.Parameters.AddWithValue("@req_count", lst[i].req_count);
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
    }
}
//        public DataTable AAA(string id, string date)
//        {
//        //    using (SqlCommand cmd = new SqlCommand())
//        //    {
//        //        StringBuilder sb = new StringBuilder();
//        //        try
//        //        {
//        //            cmd.Connection = new SqlConnection(this.ConnectionString);
//        //            cmd.Connection.Open();
//        //            //SqlTransaction tran = cmd.Connection.BeginTransaction();
//        //            string sql_1 = @"select p.product_id from TBL_PRODUCTION_PLAN pp 
//        //                                        inner join TBL_DEMAND_PLAN dp on pp.d_id = dp.d_id
//        //                                        inner join TBL_SO_MASTER so on dp.so_id = so.so_id
//        //                                        inner join TBL_PRODUCT p on p.product_codename = so.product_name
//        //                                        where pp.plan_id = @id and pp.pro_date =@Date ";
//        //            //cmd.Transaction = tran;
//        //            cmd.CommandText = sql_1;

//        //            cmd.Parameters.AddWithValue("@id", id);
//        //            cmd.Parameters.AddWithValue("@Date", date);
//        //            SqlDataReader reader = cmd.ExecuteReader();//id


//        //            string tID = string.Empty;
//        //            reader.Read();

//        //            tID = reader[0].ToString(); //id
//        //            cmd.Parameters.Clear();
//        //            cmd.Dispose();
//        //            reader.Close();

//        //            cmd.CommandText = "GetSemiManFromBOM";
//        //            cmd.CommandType = CommandType.StoredProcedure;
//        //            cmd.Parameters.AddWithValue("@parentid", tID);


//        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
//        //            DataTable dt = new DataTable();
//        //            da.Fill(dt);
//        //            List<int> productID = new List<int>();
//        //            for (int i = 0; dt.Rows.Count > i; i++)
//        //            {
//        //               productID.Add(Convert.ToInt32(dt.Rows[i][0].ToString()));
//        //            }
//        //           //string sql_2 =@"select from "

//        //            cmd.Dispose();
//        //            return dt;
//        //        }

//        //        catch (Exception err)
//        //        {
//        //            string st = err.Message;
//                  return null;
//        //        }
//            }
//        }
//    }
//}