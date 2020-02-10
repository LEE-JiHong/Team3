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
    class SupplierService
    {
        public DataTable GetAlreadyOrderList(SupplierVO vo)
        {
            SupplierDAC dac = new SupplierDAC();
            return dac.GetAlreadyOrderList(vo);
        }
    }
}
