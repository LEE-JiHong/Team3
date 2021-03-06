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
using Team3VO;


namespace Team3DAC
{
    public class ShiftDac : ConnectionAccess
    {
        public DataTable GetShiftAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "GetShiftAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                DataTable table = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(table);
                da.Dispose();

                cmd.Connection.Close();
                return table;
            }
        }
        public bool InsertShift(ShiftVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "InsertShift";

                cmd.Parameters.AddWithValue("@m_id", vo.m_id);
                cmd.Parameters.AddWithValue("@shift_id", vo.shift_id);
                cmd.Parameters.AddWithValue("@shift_stime", vo.shift_stime);
                cmd.Parameters.AddWithValue("@shift_etime", vo.shift_etime);
                cmd.Parameters.AddWithValue("@shift_sdate", vo.shift_sdate);
                cmd.Parameters.AddWithValue("@shift_edate", vo.shift_edate);
                cmd.Parameters.AddWithValue("@shift_yn", vo.shift_yn);
                cmd.Parameters.AddWithValue("@shift_uadmin", vo.shift_uadmin);
                cmd.Parameters.AddWithValue("@shift_udate", vo.shift_udate);
                cmd.Parameters.AddWithValue("@shift_comment", vo.shift_comment);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;

            }
        }

        public bool UpdateShift(ShiftVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "UpdateShift";

                cmd.Parameters.AddWithValue("@s_id", vo.s_id);
                cmd.Parameters.AddWithValue("@m_id", vo.m_id);
                cmd.Parameters.AddWithValue("@shift_id", vo.shift_id);
                cmd.Parameters.AddWithValue("@shift_stime", vo.shift_stime);
                cmd.Parameters.AddWithValue("@shift_etime", vo.shift_etime);
                cmd.Parameters.AddWithValue("@shift_sdate", vo.shift_sdate);
                cmd.Parameters.AddWithValue("@shift_edate", vo.shift_edate);
                cmd.Parameters.AddWithValue("@shift_yn", vo.shift_yn);
                cmd.Parameters.AddWithValue("@shift_uadmin", vo.shift_uadmin);
                cmd.Parameters.AddWithValue("@shift_udate", vo.shift_udate);
                cmd.Parameters.AddWithValue("@shift_comment", vo.shift_comment);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;

            }
        }
        public ShiftVO GetShiftByID(int i)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "GetShiftByID";
                cmd.Parameters.AddWithValue("@s_id", i);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShiftVO> list = Helper.DataReaderMapToList<ShiftVO>(reader);
                cmd.Connection.Close();
                return list[0];
            }
        }
        public bool DeleteShift(int i)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "delete from TBL_MACHINE_SHIFT where s_id=@id; ";
                cmd.Parameters.AddWithValue("@id", i);
                cmd.Connection.Open();

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;

            }
        }
    }
}
