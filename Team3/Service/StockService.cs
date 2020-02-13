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

        public DataTable GetMaterialStockList(MaterialStockVO vo)
        {
            StockDAC dac = new StockDAC();
            return dac.GetMaterialStockList(vo);
        }

        public DataTable GetMaterialHistory(StockVO vo)
        {
            StockDAC dac = new StockDAC();
            return dac.GetMaterialHistory(vo);
        }

        public List<FactoryComboVO> GetFactory()
        {
            StockDAC dac = new StockDAC();
            return dac.GetFactory();
        }
    }
}
