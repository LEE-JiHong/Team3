using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3DAC;
using Team3VO;

namespace Team3
{
    class ShipmentService : ConnectionAccess
    {
        public List<ShipmentVO> GetInventoryStatusByOrder()
        {
            ShipmentDac dac = new ShipmentDac();
            return dac.GetInventoryStatusByOrder(); 
        }
        public List<ShipmentOutVO> GetClientOrder()
        {
            ShipmentDac dac = new ShipmentDac();
            return dac.GetClientOrder(); 
        }
        public bool TransferProcessing(List<ShipmentVO> list)
        {
            ShipmentDac dac = new ShipmentDac();
            return dac.TransferProcessing(list);
        }
        public bool EndProcessing(List<ShipmentOutVO> list)
        {
            ShipmentDac dac = new ShipmentDac();
            return dac.EndProcessing(list);
        }
        public int GetPresentPrice(int product_id)
        {
            ShipmentDac dac = new ShipmentDac();
            return dac.GetPresentPrice(product_id);
        }
        public DataTable GetSalesCompleteStatus()
        {
            ShipmentDac dac = new ShipmentDac();
            return dac.GetSalesCompleteStatus();
        }
    }
}
