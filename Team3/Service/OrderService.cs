using System;
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

        public List<CompanyVO> GetCompanyAll(string company_type)//납품업체만
        {
            OrderDac dac = new OrderDac();
            return dac.GetCompanyAll(company_type);
        }

        public List<ProductVO> GetProductList()
        {
            OrderDac dac = new OrderDac();
            return dac.GetProductList();
        }

        public bool AddOneSOMaster(SOMasterVO VO)
        {
            OrderDac dac = new OrderDac();
            return dac.AddOneSOMaster(VO);
        }
    }
}
