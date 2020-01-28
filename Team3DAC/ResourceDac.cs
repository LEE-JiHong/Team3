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
        //공통코드==============================================
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
        //==유저
        public List<UserVO> GetUserAll()
        {
            string sql = "select user_id,user_name from tbl_user;";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<UserVO> list = Helper.DataReaderMapToList<UserVO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        //거래처=============================================================
        /// <summary>
        /// Company 모든컬럼 select
        /// </summary>
        public List<CompanyDB_VO> GetCompanyAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetCompanyAll";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CompanyDB_VO> list = Helper.DataReaderMapToList<CompanyDB_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
        public bool InsertCompany(CompanyVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "InsertCompany";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();

                //         cmd.Parameters.AddWithValue("@company_id", vo.company_id);
                cmd.Parameters.AddWithValue("@company_code", vo.company_code);
                cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                cmd.Parameters.AddWithValue("@company_type", vo.company_type);
                cmd.Parameters.AddWithValue("@company_ceo", vo.company_ceo);
                cmd.Parameters.AddWithValue("@company_cnum", vo.company_cnum);
                cmd.Parameters.AddWithValue("@company_btype", vo.company_btype);
                cmd.Parameters.AddWithValue("@company_gtype", vo.company_gtype);
                cmd.Parameters.AddWithValue("@user_id", vo.user_id);
                cmd.Parameters.AddWithValue("@company_email", vo.company_email);
                cmd.Parameters.AddWithValue("@company_phone", vo.company_phone);
                cmd.Parameters.AddWithValue("@company_fax", vo.company_fax);
                cmd.Parameters.AddWithValue("@company_yn", vo.company_yn);
                cmd.Parameters.AddWithValue("@company_uadmin", vo.company_uadmin);
                cmd.Parameters.AddWithValue("@company_udate", vo.company_udate);
                cmd.Parameters.AddWithValue("@company_comment", vo.company_comment);
                //  cmd.Parameters.AddWithValue("@company_order_code", vo.company_order_code);

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }
        public CompanyDB_VO GetCompanyByID(int i)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetCompanyByID";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", i);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<CompanyDB_VO> list = Helper.DataReaderMapToList<CompanyDB_VO>(reader);
                cmd.Connection.Close();
                return list[0];
            }
        }

        public bool UpdateCompany(CompanyVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "UpdateCompany";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@company_id", vo.company_id);
                cmd.Parameters.AddWithValue("@company_code", vo.company_code);
                cmd.Parameters.AddWithValue("@company_name", vo.company_name);
                cmd.Parameters.AddWithValue("@company_type", vo.company_type);
                cmd.Parameters.AddWithValue("@company_ceo", vo.company_ceo);
                cmd.Parameters.AddWithValue("@company_cnum", vo.company_cnum);
                cmd.Parameters.AddWithValue("@company_btype", vo.company_btype);
                cmd.Parameters.AddWithValue("@company_gtype", vo.company_gtype);
                cmd.Parameters.AddWithValue("@user_id", vo.user_id);
                cmd.Parameters.AddWithValue("@company_email", vo.company_email);
                cmd.Parameters.AddWithValue("@company_phone", vo.company_phone);
                cmd.Parameters.AddWithValue("@company_fax", vo.company_fax);
                cmd.Parameters.AddWithValue("@company_yn", vo.company_yn);
                cmd.Parameters.AddWithValue("@company_uadmin", vo.company_uadmin);
                cmd.Parameters.AddWithValue("@company_udate", vo.company_udate);
                cmd.Parameters.AddWithValue("@company_comment", vo.company_comment);
                cmd.Parameters.AddWithValue("@company_order_code", vo.company_order_code);

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;

            }
        }
        public bool DeleteCompany(int i)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "DeleteCompany";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", i);
                cmd.Connection.Open();

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }


        //설비================================================================
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
        public bool InsertMachine(MachineVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "InsertMachine";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@mgrade_id", VO.mgrade_id);
                cmd.Parameters.AddWithValue("@m_code", VO.m_code);
                cmd.Parameters.AddWithValue("@m_name", VO.m_name);
                cmd.Parameters.AddWithValue("@m_use_sector", VO.m_use_sector);
                cmd.Parameters.AddWithValue("@m_ok_sector", VO.m_ok_sector);
                cmd.Parameters.AddWithValue("@m_ng_sector", VO.m_ng_sector);
                cmd.Parameters.AddWithValue("@m_os_yn", VO.m_os_yn);
                cmd.Parameters.AddWithValue("@m_check", VO.m_check);
                cmd.Parameters.AddWithValue("@m_comment", VO.m_comment);
                cmd.Parameters.AddWithValue("@m_yn", VO.m_yn);
                cmd.Parameters.AddWithValue("@m_uadmin", VO.m_uadmin);
                cmd.Parameters.AddWithValue("@m_udate", VO.m_udate);

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }

        public bool UpdateMachine(MachineVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "UpdateMachine";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@m_id", VO.m_id);
                cmd.Parameters.AddWithValue("@mgrade_id", VO.mgrade_id);
                cmd.Parameters.AddWithValue("@m_code", VO.m_code);
                cmd.Parameters.AddWithValue("@m_name", VO.m_name);
                cmd.Parameters.AddWithValue("@m_use_sector", VO.m_use_sector);
                cmd.Parameters.AddWithValue("@m_ok_sector", VO.m_ok_sector);
                cmd.Parameters.AddWithValue("@m_ng_sector", VO.m_ng_sector);
                cmd.Parameters.AddWithValue("@m_os_yn", VO.m_os_yn);
                cmd.Parameters.AddWithValue("@m_check", VO.m_check);
                cmd.Parameters.AddWithValue("@m_comment", VO.m_comment);
                cmd.Parameters.AddWithValue("@m_yn", VO.m_yn);
                cmd.Parameters.AddWithValue("@m_uadmin", VO.m_uadmin);
                cmd.Parameters.AddWithValue("@m_udate", VO.m_udate);

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }

        public bool DeleteMachin(int i)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "DELETE FROM [dbo].[TBL_MACHINE] WHERE m_id=@id";
                cmd.Parameters.AddWithValue("@id", i);
                cmd.Connection.Open();

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }

        //설비군================================================================
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
        public bool UpdateMachineGr(MachineGradeVO VO)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "UpdateMachineGr";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mgrade_id", VO.mgrade_id);
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
        public bool DeleteMachineGr(int i)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "DeleteMachineGr";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", i);
                cmd.Connection.Open();

                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
            }
        }

        //BOR================================================================
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
        public BORDB_VO GetBORByID(int i,string route)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "GetBORByID";

                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", i);
                cmd.Parameters.AddWithValue("@route", route);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<BORDB_VO> list = Helper.DataReaderMapToList<BORDB_VO>(reader);
                cmd.Connection.Close();
                return list[0];
            }
        }


        //공장=============================================================
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

                    cmd.Parameters.AddWithValue("@factory_grade", VO.factory_grade);
                    cmd.Parameters.AddWithValue("@factory_uadmin", VO.factory_uadmin);

                    if (VO.factory_parent == null)
                    {
                        SqlParameter param1 = new SqlParameter("@factory_parent", SqlDbType.NVarChar);
                        param1.Value = DBNull.Value;
                        cmd.Parameters.Add(param1);
                    }
                    else
                        cmd.Parameters.AddWithValue("@factory_parent", VO.factory_parent);
                    cmd.Parameters.AddWithValue("@factory_name", VO.factory_name);
                    cmd.Parameters.AddWithValue("@factory_code", VO.factory_code);
                    cmd.Parameters.AddWithValue("@factory_type", VO.factory_type);
                    cmd.Parameters.AddWithValue("@factory_yn", VO.factory_yn);
                    cmd.Parameters.AddWithValue("@factory_udate", VO.factory_udate);
                    cmd.Parameters.AddWithValue("@factory_comment", VO.factory_comment);
                    if (VO.company_id == 0)
                    {
                        SqlParameter param2 = new SqlParameter("@company_id", SqlDbType.Int);
                        param2.Value = DBNull.Value;
                        cmd.Parameters.Add(param2);
                    }
                    else
                        cmd.Parameters.AddWithValue("@company_id", VO.company_id);
                    cmd.Connection.Open();
                    var successRow = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return successRow > 0;
                }
            }
            catch (Exception err)
            {
                string st = err.Message;
                return false;

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
