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
    class PurchasingService
    {
        public DataSet GetOrderList(string planID)
        {
            PurchasingDAC dac = new PurchasingDAC();
            return dac.GetOrderList(planID);
        }

        public bool InsertOrder(List<OrderVO> list)
        {
            PurchasingDAC dac = new PurchasingDAC();
            return dac.InsertOrder(list);
        }

        public DataTable GetOrderList()
        {
            PurchasingDAC dac = new PurchasingDAC();
            return dac.GetOrderList();
        }

        public bool DeleteOrder(List<string> list)
        {
            PurchasingDAC dac = new PurchasingDAC();
            return dac.DeleteOrder(list);
        }

    }
}
