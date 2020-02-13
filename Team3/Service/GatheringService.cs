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
    public class GatheringService
    {

        public bool InsertGatheringData(string[] list)
        {
            GatheringDAC dac = new GatheringDAC();
            return dac.InsertGatheringData(list);
        }
    }
}
