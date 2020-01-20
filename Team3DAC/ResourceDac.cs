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
                cmd.Parameters.AddWithValue("@FACTORY_GRADE", VO.FACTORY_GRADE);
                cmd.Parameters.AddWithValue("@FACTORY_UADMIN", VO.FACTORY_UADMIN);
                cmd.Parameters.AddWithValue("@FACTORY_PARENT", VO.FACTORY_PARENT);
                cmd.Parameters.AddWithValue("@FACTORY_NAME", VO.FACTORY_NAME);
                cmd.Parameters.AddWithValue("@FACTORY_CODE", VO.FACTORY_CODE);
                cmd.Parameters.AddWithValue("@FACTORY_TYPE", VO.FACTORY_TYPE);
                cmd.Parameters.AddWithValue("@FACTORY_YN", VO.FACTORY_YN);
                cmd.Parameters.AddWithValue("@FACTORY_UDATE", VO.FACTORY_UDATE);
                cmd.Parameters.AddWithValue("@FACTORY_COMMENT", VO.FACTORY_COMMENT);
                cmd.Parameters.AddWithValue("COMPANY_ID", VO.COMPANY_ID);

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
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "UpdateFactory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", VO.FACTORY_ID);

                cmd.Parameters.AddWithValue("@FACTORY_GRADE", VO.FACTORY_GRADE);
                cmd.Parameters.AddWithValue("@FACTORY_UADMIN", VO.FACTORY_UADMIN);
                cmd.Parameters.AddWithValue("@FACTORY_PARENT", VO.FACTORY_PARENT);
                if (VO.FACTORY_PARENT == null)
                {
                    SqlParameter param1 = new SqlParameter("@FACTORY_PARENT", SqlDbType.NVarChar);
                    param1.Value = DBNull.Value;
                    cmd.Parameters.Add(param1);
                }
                cmd.Parameters.AddWithValue("@FACTORY_NAME", VO.FACTORY_NAME);
                cmd.Parameters.AddWithValue("@FACTORY_CODE", VO.FACTORY_CODE);
                cmd.Parameters.AddWithValue("@FACTORY_TYPE", VO.FACTORY_TYPE);
                cmd.Parameters.AddWithValue("@FACTORY_YN", VO.FACTORY_YN);
                cmd.Parameters.AddWithValue("@FACTORY_UDATE", VO.FACTORY_UDATE);
                cmd.Parameters.AddWithValue("@FACTORY_COMMENT", VO.FACTORY_COMMENT);
                cmd.Parameters.AddWithValue("@COMPANY_ID", VO.COMPANY_ID);
                if (VO.COMPANY_ID == 0)
                {
                    SqlParameter param2 = new SqlParameter("@COMPANY_ID", SqlDbType.Int);
                    param2.Value = DBNull.Value;
                    cmd.Parameters.Add(param2);

                }
                cmd.Connection.Open();
                var successRow = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return successRow > 0;
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

