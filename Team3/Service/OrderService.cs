﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;
using Team3DAC;

namespace Team3
{
    public class OrderService
    {
        public bool AddSOMaster(List<SOMasterVO> list)
        {
            OrderDac dac = new OrderDac();
            return dac.AddSOMaster(list);
        }

        public List<SOMasterVO> GetSOMasterAll()
        {
            OrderDac dac = new OrderDac();
            return dac.GetSOMasterAll();
        }

        public List<CompanyVO> GetCompanyAll()
        {
            OrderDac dac = new OrderDac();
            return dac.GetCompanyAll();
        }
    }

}