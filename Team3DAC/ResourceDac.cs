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
    /// <summary>
    /// CommonCode
    /// </summary>
    /// <returns></returns>
    public class ResourceDac : ConnectionAccess
    {
        /// <summary>
        /// CommonCode
        /// </summary>
        public List<CommonVO> GetCommonCodeAll()
        {
            string sql = "GetCommonCodeAll";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CommonVO> list = Helper.DataReaderMapToList<CommonVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        /// <summary>
        /// Company 모든컬럼 select
        /// </summary>
        public List<CompanyVO> GetCompanyAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetCompanyAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        /// <summary>
        /// Machine 설비 모든컬럼 select
        /// </summary>
        public List<MachineVO> GetMachineAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetMachineAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<MachineVO> list = Helper.DataReaderMapToList<MachineVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        /// <summary>
        /// 설비군 모든 컬럼 select
        /// </summary>
        public List<MachineGradeVO> GetMachineGrpAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetMachineGrpAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<MachineGradeVO> list = Helper.DataReaderMapToList<MachineGradeVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        public bool InsertMachineGr(MachineGradeVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "InsertMachineGr";
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                //  cmd.Parameters.AddWithValue("@MGRADE_ID", VO.mgrade_id);
                cmd.Parameters.AddWithValue("@mgrade_code", VO.mgrade_code);
                cmd.Parameters.AddWithValue("@mgrade_name", VO.mgrade_name);
                cmd.Parameters.AddWithValue("@mgrade_yn", VO.mgrade_yn);
                cmd.Parameters.AddWithValue("@mgrade_uadmin", VO.mgrade_uadmin);
                cmd.Parameters.AddWithValue("@mgrade_udate", VO.mgrade_udate);
                cmd.Parameters.AddWithValue("@mgrade_comment", VO.mgrade_comment);
                cmd.Connection.Open();

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }
        public List<BORDB_VO> GetBORAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetBORAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<BORDB_VO> list = Helper.DataReaderMapToList<BORDB_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        public List<FactoryDB_VO> GetFactoryAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetFactoryAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<FactoryDB_VO> list = Helper.DataReaderMapToList<FactoryDB_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        public bool InsertFactory(FactoryVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "InsertFactory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FACTORY_GRADE", VO.factory_grade);
                cmd.Parameters.AddWithValue("@FACTORY_UADMIN", VO.factory_uadmin);

                if (VO.factory_parent == null)
                {
                    SqlParameter param1 = new SqlParameter("@FACTORY_PARENT", SqlDbType.NVarChar);
                    param1.Value = DBNull.Value;
                    cmd.Parameters.Add(param1);
                }
                else
                { cmd.Parameters.AddWithValue("@FACTORY_PARENT", VO.factory_parent); }
                cmd.Parameters.AddWithValue("@FACTORY_NAME", VO.factory_name);
                cmd.Parameters.AddWithValue("@FACTORY_CODE", VO.factory_code);
                cmd.Parameters.AddWithValue("@FACTORY_TYPE", VO.factory_type);
                cmd.Parameters.AddWithValue("@FACTORY_YN", VO.factory_yn);
                cmd.Parameters.AddWithValue("@FACTORY_UDATE", VO.factory_udate);
                cmd.Parameters.AddWithValue("@FACTORY_COMMENT", VO.factory_comment);
                if (VO.company_id == 0)
                {
                    SqlParameter param2 = new SqlParameter("@COMPANY_ID", SqlDbType.Int);
                    param2.Value = DBNull.Value;
                    cmd.Parameters.Add(param2);
                }
                else
                    cmd.Parameters.AddWithValue("COMPANY_ID", VO.company_id);

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }

        public FactoryVO GetFactoryByID(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetFactoryByID";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(reader);
                cmd.Connection.Close();
                return list[0];
            }
        }
        public bool UpdateFactory(FactoryVO VO)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "UpdateFactory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", VO.factory_id);

                    cmd.Parameters.AddWithValue("@FACTORY_GRADE", VO.factory_grade);
                    cmd.Parameters.AddWithValue("@FACTORY_UADMIN", VO.factory_uadmin);
                    cmd.Parameters.AddWithValue("@FACTORY_PARENT", VO.factory_parent);
                    if (VO.factory_parent == null)
                    {
                        SqlParameter param1 = new SqlParameter("@FACTORY_PARENT", SqlDbType.NVarChar);
                        param1.Value = DBNull.Value;
                        cmd.Parameters.Add(param1);
                    }
                    cmd.Parameters.AddWithValue("@FACTORY_NAME", VO.factory_name);
                    cmd.Parameters.AddWithValue("@FACTORY_CODE", VO.factory_code);
                    cmd.Parameters.AddWithValue("@FACTORY_TYPE", VO.factory_type);
                    cmd.Parameters.AddWithValue("@FACTORY_YN", VO.factory_yn);
                    cmd.Parameters.AddWithValue("@FACTORY_UDATE", VO.factory_udate);
                    cmd.Parameters.AddWithValue("@FACTORY_COMMENT", VO.factory_comment);
                    if (VO.company_id == 0)
                    {
                        SqlParameter param2 = new SqlParameter("@COMPANY_ID", SqlDbType.Int);
                        param2.Value = DBNull.Value;
                        cmd.Parameters.Add(param2);
                    }
                    cmd.Parameters.AddWithValue("@COMPANY_ID", VO.company_id);
                    cmd.Connection.Open();
                    var successRow = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return successRow > 0;
                }
            }
            catch (Exception err)
            {
                return false;
                string st = err.Message;
            }
        }
        public bool DeleteFactory(int id)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "DeleteFactory";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }
    }
}
