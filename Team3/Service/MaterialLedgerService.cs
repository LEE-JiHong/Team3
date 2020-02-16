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

        public bool AddMaterialQauntity(List<MaterialReceivingVO> list)
        {
            MaterialLedgerDAC dac = new MaterialLedgerDAC();
            return dac.AddMaterialQauntity(list);
        }

        public DataTable GetMaterialInList()
        {
            MaterialLedgerDAC dac = new MaterialLedgerDAC();
            return dac.GetMaterialInList();
        }

        public bool CancelMaterial(List<MaterialReceivingVO> list)
        {
            MaterialLedgerDAC dac = new MaterialLedgerDAC();
            return dac.CancelMaterial(list);
        }
    }
}
