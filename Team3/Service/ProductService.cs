using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;
using Team3DAC;

namespace Team3
{
    class ProductService
    {
        /// <summary>
        /// 모든 Product 조회
        /// </summary>
        /// <returns></returns>
        public List<ProductVO> GetAllProducts()
        {
            ProductDac dac = new ProductDac();
            return dac.GetProductsAll();
        }

        public bool AddProduct(ProductVO vo)
        {
            ProductDac dac = new ProductDac();
            return dac.AddProduct(vo);
        }
    }
}
