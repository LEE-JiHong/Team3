using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Team3.Service;
using Team3VO;
namespace Team3
{
    public partial class Business_showings : Team3.VerticalGridBaseForm
    {
        public Business_showings()
        {
            InitializeComponent();
        }

        private void Business_showings_Load(object sender, EventArgs e)
        {
            ProcessService P_service = new ProcessService();
            List<WorkRecode_VO> W_lst = P_service.WorkRecode();
            dataGridView1.DataSource = W_lst;
            List<WorkRecode_VO> n_lst = P_service.GetWork();
            dataGridView2.DataSource = n_lst;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<WorkRecode_VO> lst = (List<WorkRecode_VO>)dataGridView1.DataSource;
            ProcessService P_Service = new ProcessService();
         
            List<DMRVO> D_lst = new List<DMRVO>();
            DMRVO vo = new DMRVO();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                vo.product_codename = dataGridView1.Rows[i].Cells[6].Value.ToString(); //제품코드네임 6 "U_JOINT_C"

                vo.factory_name = dataGridView1.Rows[i].Cells[15].Value.ToString(); //창고명  m_use_sector 15 "제품창고"
                vo.pro_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());//pro_id 1  57
                vo.plan_id = dataGridView1.Rows[i].Cells[16].Value.ToString();//plan_id 

                D_lst = (P_Service.GetDMRMgt(vo));
                
            }
            List<WorkRecode_VO> w_lst=(List<WorkRecode_VO>)dataGridView1.DataSource;
            bool bResult = P_Service.FinishRecode(D_lst,w_lst);
         
            if(bResult)
            {
                MessageBox.Show("성공");
            }
           else  {
                MessageBox.Show("실패");
            }
        }
        
    }
}
