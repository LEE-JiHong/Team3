using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;
using Team3DAC;

namespace Team3
{
    public class OrderService
    {
        public bool AddSOMaster(SOMasterVO vo)
        {
            OrderDac dac = new OrderDac();
            return dac.AddSOMaster(vo);
        }
    }
}
