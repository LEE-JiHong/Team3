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
    public class ResourceDac : ConnectionAccess
    {
        /// <summary>
        /// CommonCode
        /// </summary>
        /// <returns></returns>
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
    }
}
