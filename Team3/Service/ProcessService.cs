using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3DAC;
using Team3VO;

namespace Team3.Service
{
   public class ProcessService
    {
        public DataTable GetProductionPlanCheck(string startDate , string endDate)
        {
            ProcessDac dac = new ProcessDac();
            return dac.GetProductionPlanCheck(startDate,endDate);
        }
    }
}
