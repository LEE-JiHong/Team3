using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
  public  class MachineGradeVO
    {
        public int MGRADE_ID { get; set; }
        public string MGRADE_CODE { get; set; }
        public string MGRADE_NAME { get; set; }
        public string MGRADE_YN { get; set; }
        public string MGRADE_UADMIN { get; set; }
        public string MGRADE_UDATE { get; set; }
        public string MGRADE_COMMENT { get; set; }
        public MachineGradeVO()
        {

        }
    }
}
