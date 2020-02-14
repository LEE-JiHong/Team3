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
        public bool TransferProcessing(List<ShipmentVO> list)
        {
            ShipmentDac dac = new ShipmentDac();
            return dac.TransferProcessing(list);
        }
    }
}
