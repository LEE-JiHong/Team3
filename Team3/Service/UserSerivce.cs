using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;
using Team3DAC;
using System.Data;

namespace Team3
{
    public class UserService
    {
        public int LoginCheck(string id, string pwd)
        {
            UserDac dac = new UserDac();
            return dac.LoginCheck(id, pwd);
        }
    }
}
