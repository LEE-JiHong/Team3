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

        /// <summary>
        /// 창고목록 가져오기
        /// </summary>
        /// <returns></returns>
        public List<FactoryComboVO> GetFactory()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = $"select factory_name, factory_code from TBL_FACTORY";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<FactoryComboVO> list = Helper.DataReaderMapToList<FactoryComboVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// 입고창고목록 가져오기
        /// </summary>
        /// <returns></returns>
        public List<FactoryComboVO> GetInFactory()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = $"select factory_name, factory_code from TBL_FACTORY where factory_type = 'FAC200'";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<FactoryComboVO> list = Helper.DataReaderMapToList<FactoryComboVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public DataTable GetMaterialStockList(MaterialStockVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                //sql.Append($"select w_id, plan_id, factory_code, factory_name, p.product_codename, product_name, w_count_present, common_name as product_type from TBL_WAREHOUSE w inner join TBL_FACTORY f on w.factory_id = f.factory_id inner join TBL_PRODUCT p on p.product_id = w.product_id inner join TBL_COMMON_CODE c on c.common_value = p.product_type where 1=1");

                sql.Append($"select w.factory_id, factory_code,p.product_id,sum(w_count_present) as w_count_present, factory_name, product_codename, product_name, common_name as product_type from TBL_WAREHOUSE w inner join TBL_FACTORY f on w.factory_id = f.factory_id inner join TBL_PRODUCT p on p.product_id = w.product_id inner join TBL_COMMON_CODE c on c.common_value = p.product_type where 1=1");

                if (vo.factory_code != null)
                {
                    sql.Append(" and f.factory_code = @factory_code");
                    cmd.Parameters.AddWithValue("@factory_code", vo.factory_code);
                }

                if (vo.product_type != null)
                {
                    sql.Append($" and common_name = @product_type");
                    cmd.Parameters.AddWithValue("@product_type", vo.product_type);
                }

                if (vo.product_codename != null)
                {
                    sql.Append($" and product_codename like '%{vo.product_codename}%'");
                    //cmd.Parameters.AddWithValue("@product_codename", vo.order_id);
                }

                sql.Append($" group by w.factory_id, p.product_id, factory_name, factory_code, product_codename, product_name, common_name");

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

        public DataTable GetMaterialHistory(StockVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();

                //sql.Append($"select w_id, plan_id, factory_code, factory_name, p.product_codename, product_name, w_count_present, common_name as product_type from TBL_WAREHOUSE w inner join TBL_FACTORY f on w.factory_id = f.factory_id inner join TBL_PRODUCT p on p.product_id = w.product_id inner join TBL_COMMON_CODE c on c.common_value = p.product_type where 1=1");

                sql.Append($"select wh_id, w.w_id, w.product_id, product_name, product_codename, wh_product_count, wh_udate, wh_comment, common_name ,plan_id from TBL_WAREHOUSE_HIS h inner join TBL_WAREHOUSE w on h.w_id = w.w_id inner join TBL_PRODUCT p on p.product_id = w.product_id inner join TBL_COMMON_CODE c on c.common_value = h.wh_category inner join TBL_FACTORY f on f.factory_id = w.factory_id where p.product_codename = @product_codename and factory_code = @factory_code order by wh_id desc");


                cmd.Parameters.AddWithValue("@product_codename", vo.product_codename);
                cmd.Parameters.AddWithValue("@factory_code", vo.factory_code);

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

        public DataTable GetInOutHistory(MaterialSearchVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder sql = new StringBuilder();
                    
                sql.Append($"select wh_id, factory_name, product_codename, c1.common_name as product_type,product_name, order_id, wh_product_count,pp.price_present, (wh_product_count * pp.price_present) as totalprice, wh_udate, wh_comment, c.common_name as wh_category from TBL_WAREHOUSE_HIS h inner join TBL_PRODUCT p on h.product_id = p.product_id inner join TBL_P_PRICE pp on pp.product_id = p.product_id inner join TBL_COMMON_CODE c on c.common_value = h.wh_category inner join TBL_WAREHOUSE w on w.w_id = h.w_id inner join TBL_FACTORY f on f.factory_id = w.factory_id inner join TBL_COMMON_CODE c1 on c1.common_value = p.product_type where pp.price_edate = '9999-12-31' and CONVERT (DATETIME, wh_udate) >= CONVERT (DATETIME, @startDate) and CONVERT (DATETIME, wh_udate) <= CONVERT (DATETIME, @endDate)");

                if (vo.factory_name != null)
                {
                    sql.Append(" and factory_name = @factory_name");
                    cmd.Parameters.AddWithValue("@factory_name", vo.factory_name);
                }

                if (vo.product_type != null)
                {
                    sql.Append($" and c1.common_name = @product_type");
                    cmd.Parameters.AddWithValue("@product_type", vo.product_type);
                }

                if (vo.product_name != null)
                {
                    sql.Append($" and product_name like '%{vo.product_name}%'");
                }

                sql.Append($" order by wh_udate desc");

                cmd.Parameters.AddWithValue("@startDate", vo.startDate);
                cmd.Parameters.AddWithValue("@endDate", vo.endDate);

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
