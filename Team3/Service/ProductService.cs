using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;
using Team3DAC;

namespace Team3.Service
{
    class ProductService
    {
        public List<ProductVO> GetAllProducts()
        {
            ProductDac dac = new ProductDac();
            List<ProductVO> list =  dac.GetProductsAll();
            return list;
        }
    }
}
