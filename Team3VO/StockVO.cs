using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
    //Supplier(입고대기) 
    //담당 : 이지홍

    /// <summary>
    /// 자재재고현황에서 이력조회 넘길 때 VO
    /// </summary>
    public class StockVO
    {
        public string product_codename { get; set; }
        public string factory_code { get; set; }
    }

    /// <summary>
    /// 자재재고현황 조건검색 vo
    /// </summary>
    public class MaterialStockVO
    { 
        public string product_codename { get; set; }
        public string product_type { get; set; }
        public string factory_code { get; set; }
    }

    /// <summary>
    /// 콤보박스에 바인딩할 창고 vo
    /// </summary>
    public class FactoryComboVO
    { 
        public string factory_name { get; set; }
        public string factory_code { get; set; }
    }

}
