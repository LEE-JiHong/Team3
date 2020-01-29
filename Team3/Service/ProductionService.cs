using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3DAC;
using Team3VO;

namespace Team3
{
    public class ProductionService
    {
        public List<BomVO> GetBomAll()
        {
            BomDac dac = new BomDac();
            return dac.GetBomAll();
        }

    }
}
