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
    public class ProductionService
    {
        BomDac B_dac = new BomDac();
        ProductionDac P_dac = new ProductionDac();
        public List<BomVO> GetBomAll()
        {
           
            return B_dac.GetBomAll();
        }
        public DataTable GetProductPlan(string planid, string startDate, string endDate)
        {
            return P_dac.GetProductPlan(planid, startDate, endDate);
        }
    }
}
