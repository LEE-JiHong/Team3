using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3VO
{
  public  class MachineGradeVO
    {
        public int mgrade_id { get; set; } //id
        public string mgrade_code { get; set; }//설비군코드
        public string mgrade_name { get; set; }//설비군명
        public string mgrade_yn { get; set; }//사용유무
        public string mgrade_uadmin { get; set; }//수정자
        public string mgrade_udate { get; set; }//수정시간
        public string mgrade_comment { get; set; }//시설설명
      
    }
}
