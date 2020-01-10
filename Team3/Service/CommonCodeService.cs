using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3DAC;
using Team3VO;

namespace Team3.Service
{
    class CommonCodeService
    {
        /// <summary>
        /// CommonCode 컬럼 모두 select
        /// </summary>
        public List<CommonVO> GetCommonCodeAll()
        {
            ResourceDac dac = new ResourceDac();
            return dac.GetCommonCodeAll();
        }
    }
}
