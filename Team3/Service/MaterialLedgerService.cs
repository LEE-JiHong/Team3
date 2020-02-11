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
    public class MaterialLedgerService
    {

        public List<OrderStateVO> GetOrderState()
        {
            MaterialLedgerDAC dac = new MaterialLedgerDAC();
            return dac.GetOrderState();
        }

        public DataTable GetWatingReceivingList(SupplierVO vo)
        {
            MaterialLedgerDAC dac = new MaterialLedgerDAC();
            return dac.GetWatingReceivingList(vo);
        }
    }
}
