using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3VO;
using Team3DAC;
using System.Data;

namespace Team3
{
    public class StockService
    {

        public List<CommonVO> GetProductType(string product_type)
        {
            StockDAC dac = new StockDAC();
            return dac.GetProductType(product_type);
        }

        public DataTable GetMaterialStockList()
        {
            StockDAC dac = new StockDAC();
            return dac.GetMaterialStockList();
        }
    }
}
