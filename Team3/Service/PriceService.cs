using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3DAC;
using Team3VO;

namespace Team3
{
    class PriceService
    {
        public List<PriceInfoVO> GetPriceInfo(string company_type)
        {
            PriceDac dac = new PriceDac();
            return dac.GetPriceInfo(company_type);
        }
        public bool AddPriceInfo(PriceInfoVO vo)
        {
            PriceDac dac = new PriceDac();
            return dac.AddPriceInfo(vo);
        }
        public bool UpdatePriceInfo(PriceInfoVO vo)
        {
            PriceDac dac = new PriceDac();
            return dac.UpdatePriceInfo(vo);
        }
    }
}
