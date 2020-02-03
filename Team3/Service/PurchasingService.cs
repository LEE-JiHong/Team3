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
    }
}
