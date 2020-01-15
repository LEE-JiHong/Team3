﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;
using Team3WebAPI;

namespace Team3
{
    class BomService
    {
        /// <summary>
        /// 모든 Bom 조회
        /// </summary>
        /// <returns></returns>
        public List<BomVO> GetBomAll()
        {
            BomDac dac = new BomDac();
            return dac.GetBomAll();
        }

        /// <summary>
        /// Bom 신규 추가
        /// </summary>
        /// <returns></returns>
        public bool AddBom(BomVO vo)
        {
            BomDac dac = new BomDac();
            return dac.AddBom(vo);
        }
        
        
        
    }
}
