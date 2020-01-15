﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;

namespace Team3WebAPI
{
    public class BomDac : ConnectionAccess
    {
        /// <summary>
        /// 모든 Bom 조회
        /// </summary>
        /// <returns></returns>
        public List<BomVO> GetBomAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetBomAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<BomVO> list = Helper.DataReaderMapToList<BomVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        public bool AddBom(BomVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "AddBom";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@bom_id", VO.bom_id);
                cmd.Parameters.AddWithValue("@bom_parent_id", VO.bom_parent_id);
                cmd.Parameters.AddWithValue("@product_id", VO.product_id);
                cmd.Parameters.AddWithValue("@bom_use_count", VO.bom_use_count);
                cmd.Parameters.AddWithValue("@bom_sdate", VO.bom_sdate);
                cmd.Parameters.AddWithValue("@bom_edate", VO.bom_edate);
                cmd.Parameters.AddWithValue("@bom_yn", VO.bom_yn);
                cmd.Parameters.AddWithValue("@plan_id", VO.plan_id);
                cmd.Parameters.AddWithValue("@bom_comment", VO.bom_comment);
                cmd.Parameters.AddWithValue("@bom_uadmin", VO.bom_uadmin);
                cmd.Parameters.AddWithValue("@bom_udate", VO.bom_udate);
               


                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }

        }
    }
}
