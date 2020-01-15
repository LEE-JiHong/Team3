using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Team3VO;

namespace Team3WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        /// <summary>
        /// 모든 Product 조회
        /// </summary>
        /// <returns></returns>
        // GET: api/Product
        public List<ProductVO> GetAllProducts()
        {
            ProductDac dac = new ProductDac();
            return dac.GetProductsAll();
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public bool AddProduct(ProductVO vo)
        {
            ProductDac dac = new ProductDac();
            return dac.AddProduct(vo);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
