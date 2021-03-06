﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3DAC;
using Team3VO;

namespace Team3.Service
{
    public class ProcessService
    {
        public DataTable GetProductionPlanCheck(string startDate, string endDate)
        {
            ProcessDac dac = new ProcessDac();
            return dac.GetProductionPlanCheck(startDate, endDate);
        }
        public bool UpdateCommand(int num, string tdate)
        {
            ProcessDac dac = new ProcessDac();
            return dac.UpdateCommand(num, tdate);
        }
        public DataTable GetProductionPlanCheckHis(string startDate, string endDate)
        {
            ProcessDac dac = new ProcessDac();
            return dac.GetProductionPlanCheckHis(startDate, endDate);
        }
        //public DataTable AAA(string id, string date)
        //{
        //    ProcessDac dac = new ProcessDac();
        //    return dac.AAA(id, date);
        //}
        public DataTable GetProductFromBOM(string i)
        {
            ProcessDac dac = new ProcessDac();
            return dac.GetProductFromBOM(i);
        }
        public List<DMRVO> GetDMRMgt(DMRVO vo)
        {
            ProcessDac dac = new ProcessDac();
            return dac.GetDMRMgt(vo);
        }
        public DataTable GetDMR_dt(DMRVO vo)
        {
            ProcessDac dac = new ProcessDac();
            return dac.GetDMR_dt(vo);
        }
        public bool tranWH(List<DMRVO> lst)
        {
            ProcessDac dac = new ProcessDac();
            return dac.tranWH(lst);
        }
        public List<WorkRecode_VO> WorkRecode()
        {
            ProcessDac dac = new ProcessDac();
            return dac.WorkRecode();
        }
        public bool FinishRecode(List<DMRVO> lst, List<WorkRecode_VO> w_lst)
        {
            ProcessDac dac = new ProcessDac();
            return dac.FinishRecode(lst, w_lst);
        }
        public List<WorkRecode_VO> GetWork()
        {
            ProcessDac dac = new ProcessDac();
            return dac.GetWork();
        }
    }
}
