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
    public class OrderService
    {
        public bool AddSOMaster(List<SOMasterVO> list)
        {
            OrderDac dac = new OrderDac();
            return dac.AddSOMaster(list);
        }

        public List<SOMasterVO> GetSOMasterAll(WhereSoVO vo)
        {
            OrderDac dac = new OrderDac();
            return dac.GetSOMasterAll(vo);
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

        public bool UpdateOneSOMaster(SOMasterVO VO)
        {
            OrderDac dac = new OrderDac();
            return dac.UpdateOneSOMaster(VO);
        }

        public List<DayVO> GetDays(string firstDate, string endDate)
        {
            OrderDac dac = new OrderDac();
            return dac.GetDays(firstDate, endDate);
        }

        public List<string> GetPlanID()
        {
            OrderDac dac = new OrderDac();
            return dac.GetPlanID();
        }

        public int GetPlanIDINSOMaster(string planID)
        {
            OrderDac dac = new OrderDac();
            return dac.GetPlanIDINSOMaster(planID);
        }

        public List<SOMasterVO> GetSOMaster(string planID)
        {
            OrderDac dac = new OrderDac();
            return dac.GetSOMaster(planID);
        }

        public List<DemandPlanVO> GetDemandPlanFromPlanID(string planID)
        {
            OrderDac dac = new OrderDac();
            return dac.GetDemandPlanFromPlanID(planID);
        }

        public bool AddDemandPlan(List<DemandPlanVO> list)
        {
            OrderDac dac = new OrderDac();
            return dac.AddDemandPlan(list);
        }

        public DataTable GetDemandPlan(string firstDate, string endDate, string planID)
        {
            OrderDac dac = new OrderDac();
            return dac.GetDemandPlan(firstDate, endDate, planID);
        }

        public bool AddProductionPlan(List<ProductionPlanVO> list)
        {
            OrderDac dac = new OrderDac();
            return dac.AddProductionPlan(list);
        }

        public DataTable GetMRP(string planID, string firstDate, string endDate)
        {
            OrderDac dac = new OrderDac();
            return dac.GetMRP(planID, firstDate, endDate);
        }

        public int SearchPlanIDInDemand(string plan_id)
        {
            OrderDac dac = new OrderDac();
            return dac.SearchPlanIDInDemand(plan_id);
        }
        public int GetMaxUPHCount(string plan_id)
        {
            OrderDac dac = new OrderDac();
            return dac.GetMaxUPHCount(plan_id);
        }
    }
}
