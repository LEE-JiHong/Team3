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
    class DemandDac : ConnectionAccess
    {
        //public List<CommonVO> GetCommonCode()
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.Connection = new SqlConnection(this.ConnectionString);
        //        cmd.CommandText = "GetCommonCode";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        List<CommonVO> list = Helper.DataReaderMapToList<CommonVO>(reader);
        //        cmd.Connection.Close();
        //        return list;
        //    }
        //}

    }
}
