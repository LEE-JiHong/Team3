using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3DAC;
using Team3VO;


namespace Team3
{
    public class ShiftService
    {
    
        public DataTable GetShiftAll()
        {
            ShiftDac dac = new ShiftDac();
            return dac.GetShiftAll();
        }
        public bool InsertShift(ShiftVO vo)
        {
            ShiftDac dac = new ShiftDac();
            return dac.InsertShift(vo);
        }
        public bool UpdateShift(ShiftVO vo)
        {
            ShiftDac dac = new ShiftDac();
            return dac.UpdateShift(vo);
        }
    }
}
