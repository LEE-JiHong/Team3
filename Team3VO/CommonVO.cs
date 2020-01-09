using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //공통코드 VO
    class CommonVO
    {
        private int common_id;
        private string common_type;
        private string common_value;
        private string common_name;

        public CommonVO()
        {

        }
        public CommonVO(int common_id, string common_type, string common_value,string common_name)
        {
            this.common_id = common_id;
            this.common_type = common_type;
            this.common_value = common_value;
            this.common_name = common_name;
        }
    }
}
