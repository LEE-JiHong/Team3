﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;
using Team3WebAPI;

namespace Team3
{
  public  class CommonCodeService
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
