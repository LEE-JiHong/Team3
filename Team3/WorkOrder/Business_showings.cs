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

            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "작업지시번호", "worknum", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "", "pro_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "시작일", "pro_date", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "시작시간", "pd_stime", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "완료시간", "pd_etime", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "product_id", "product_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "품목코드명", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "품목", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상태", "pro_state", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "상태", "common_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "작업시간", "worktime", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "작업수량", "pro_count", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "양품수량", "ok_cnt", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "불량수량", "ng_cnt", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "설비명", "m_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "소진창고", "m_use_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "양품창고", "m_ok_sector", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "plan_id", "plan_id", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "요청일", "req_date", false, 100, DataGridViewContentAlignment.MiddleLeft);// 요청일
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "사유", "reason", false, 100, DataGridViewContentAlignment.MiddleLeft); //사유
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "w_id", "w_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "order_id", "order_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "m_id", "m_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "소진창고", "m_use_sector_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "양품창고", "m_ok_sector_id", false, 100, DataGridViewContentAlignment.MiddleLeft);

            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "작업지시번호", "worknum", true, 120, DataGridViewContentAlignment.MiddleLeft);
          GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "", "pro_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "시작일", "pro_date", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "시작시간", "pd_stime", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "완료시간", "pd_etime", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "product_id", "product_id",false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "품목코드명", "product_codename", true, 120, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "품목", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "상태", "pro_state", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "상태", "common_name", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "작업시간", "worktime", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "작업수량", "pro_count", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "양품수량", "ok_cnt", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "불량수량", "ng_cnt", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "설비명", "m_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "소진창고", "m_use_sector", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "양품창고", "m_ok_sector", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "plan_id", "plan_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "요청일", "req_date", false, 100, DataGridViewContentAlignment.MiddleLeft);// 요청일
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "사유", "reason", false, 100, DataGridViewContentAlignment.MiddleLeft); //사유
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "w_id", "w_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "order_id", "order_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "m_id", "m_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "소진창고", "m_use_sector_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "양품창고", "m_ok_sector_id", false, 100, DataGridViewContentAlignment.MiddleLeft);

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

                vo.factory_name = dataGridView1.Rows[i].Cells[16].Value.ToString(); //창고명  m_use_sector 15 "제품창고"
                vo.pro_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());//pro_id 1  57
                vo.plan_id = dataGridView1.Rows[i].Cells[17].Value.ToString();//plan_id 

                D_lst = (P_Service.GetDMRMgt(vo));
                
            }
            List<WorkRecode_VO> w_lst=(List<WorkRecode_VO>)dataGridView1.DataSource;
            bool bResult = P_Service.FinishRecode(D_lst,w_lst);
            List<WorkRecode_VO> n_lst = P_Service.GetWork();
            dataGridView2.DataSource = n_lst;
            if (bResult)
            {
                MessageBox.Show("성공");
            }
           else  {
                MessageBox.Show("실패");
            }
        }
        
    }
}
