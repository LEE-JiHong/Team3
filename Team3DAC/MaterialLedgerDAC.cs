﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;

namespace Team3DAC
{
    public class MaterialLedgerDAC : ConnectionAccess
    {
        /// <summary>
        /// 주문상태 리스트 가져오기
        /// </summary>
        /// <returns></returns>
        public List<OrderStateVO> GetOrderState()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                sql.Append($"select common_name as state_name, common_value as state_code from TBL_COMMON_CODE where common_type = 'material_order_state' and common_value != 'P_COMPLETE'");

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<OrderStateVO> list = Helper.DataReaderMapToList<OrderStateVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public DataTable GetWatingReceivingList(SupplierVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                sql.Append($"select order_serial, concat(LEFT(order_serial, 4),'-',SUBSTRING(order_serial, 5,2),'-',SUBSTRING(order_serial, 7,2)) as order_ddate, c.company_name, p.product_codename, product_name, o.order_count, o.order_pdate, cc.common_name, o.order_sdate from TBL_ORDER o inner join TBL_PRODUCT p on o.product_id = p.product_id inner join TBL_COMPANY c on p.product_demand_com = c.company_code inner join TBL_COMMON_CODE cc on o.order_state = cc.common_value where CONVERT (DATETIME, o.order_pdate) >= CONVERT (DATETIME, @startDate) and CONVERT (DATETIME, o.order_pdate) <= CONVERT (DATETIME, @endDate)");

                if (vo.company_name != null)
                {
                    sql.Append(" and company_name = @company_name");
                    cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                }

                if (vo.order_state != null)
                {
                    sql.Append($" and order_state = @order_state");
                    cmd.Parameters.AddWithValue("@order_state", vo.order_state);
                }
                else
                {
                    sql.Append($" and order_state != 'P_COMPLETE'");
                }

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@startDate", vo.start_date);
                cmd.Parameters.AddWithValue("@endDate", vo.end_date);

                DataTable dataTable = new DataTable();

                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
                da.Dispose();

                cmd.Connection.Close();
                return dataTable;
            }
        }

        /// <summary>
        /// 자재입고
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddMaterialQauntity(List<MaterialReceivingVO> list)
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

                    foreach (MaterialReceivingVO item in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@order_serial", item.order_serial);

                        cmd.CommandText = @"select plan_id from TBL_ORDER where order_serial = @order_serial";

                        item.plan_id = cmd.ExecuteScalar().ToString();

                        cmd.Parameters.AddWithValue("@plan_id", item.plan_id);
                        cmd.Parameters.AddWithValue("@product_codename", item.product_codename);

                        cmd.CommandText = @"select factory_id, product_id from TBL_PRODUCT p inner join TBL_FACTORY f on p.product_in_sector = f.factory_code where product_codename = @product_codename";

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            item.factory_id = Convert.ToInt32(reader["factory_id"]);
                            item.product_id = Convert.ToInt32(reader["product_id"]);
                        }
                        reader.Close();

                        cmd.Parameters.AddWithValue("@factory_id", item.factory_id);
                        cmd.Parameters.AddWithValue("@product_id", item.product_id);

                        cmd.CommandText = @"select w_id from TBL_WAREHOUSE where plan_id = @plan_id and factory_id = @factory_id and product_id = @product_id";

                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        if (result > 0)
                        {
                            cmd.Parameters.AddWithValue("@w_id", result);
                            cmd.CommandText = @"update TBL_WAREHOUSE set w_count_present = w_count_present + @order_count, w_count_past = w_count_present where w_id = @w_id";
                        }
                        else
                        {
                            cmd.CommandText = @"insert into TBL_WAREHOUSE(plan_id, factory_id, product_id, w_count_present,w_count_past) values (@plan_id, @factory_id, @product_id, @order_count, 0)";
                        }

                        cmd.Parameters.AddWithValue("@order_count", item.order_count);

                        cmd.ExecuteNonQuery();

                        cmd.Parameters.AddWithValue(@"order_pdate", item.order_pdate);

                        cmd.CommandText = @"update TBL_ORDER set order_qcount = order_qcount - @order_count, order_pdate = @order_pdate where order_serial = @order_serial";

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"select order_qcount from TBL_ORDER where order_serial = @order_serial";

                        int order_qcount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (order_qcount == 0)
                        {
                            cmd.CommandText = @"update TBL_ORDER set order_state = 'P_COMPLETE' where order_serial = @order_serial";
                            cmd.ExecuteNonQuery();
                        }

                        cmd.Parameters.AddWithValue("@wh_comment", item.product_name + " 입고");
                        cmd.Parameters.AddWithValue("@wh_udate", DateTime.Now.ToShortDateString());

                        cmd.CommandText = @"select w_id from TBL_WAREHOUSE where plan_id = @plan_id and factory_id = @factory_id and product_id = @product_id";

                        int w_id = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.AddWithValue("@w_id", w_id);

                        cmd.CommandText = "insert into TBL_WAREHOUSE_HIS(w_id, product_id, order_id, wh_product_count, wh_udate, wh_comment, wh_category) values (@w_id, @product_id, @order_serial, @order_count, @wh_udate, @wh_comment, 'P_ORDER_IN')";

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

        /// <summary>
        /// 자재입고현황 목록 - warehouse_his로 하는 거 같음
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public DataTable GetMaterialInList(SupplierVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                sql.Append($"SELECT distinct w_id, w.plan_id, product_codename, product_name, factory_name, (w.w_count_present-w.w_count_past) as '입고량', order_serial, order_pdate FROM TBL_WAREHOUSE w inner join TBL_FACTORY f on w.factory_id = f.factory_id inner join TBL_ORDER o on o.plan_id = w.plan_id inner join TBL_PRODUCT p on p.product_id = w.product_id inner join TBL_COMPANY c on c.company_code = p.product_demand_com WHERE f.factory_type = 'FAC200'");

                if (vo.company_name != null)
                {
                    sql.Append(" and company_name = @company_name");
                    cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                }

                if (vo.order_state != null)
                {
                    sql.Append($" and order_state = @order_state");
                    cmd.Parameters.AddWithValue("@order_state", vo.order_state);
                }
                else
                {
                    sql.Append($" and order_state != 'P_COMPLETE'");
                }

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@startDate", vo.start_date);
                cmd.Parameters.AddWithValue("@endDate", vo.end_date);

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
