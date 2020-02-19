using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Team3.Service;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;

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
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView2, "product_id", "product_id", false, 100, DataGridViewContentAlignment.MiddleLeft);
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
            GridViewUtil.SetDataGridView(dataGridView2);
            ProcessService P_service = new ProcessService();
            List<WorkRecode_VO> W_lst = P_service.WorkRecode();
            dataGridView1.DataSource = W_lst;
            List<WorkRecode_VO> n_lst = P_service.GetWork();
            dataGridView2.DataSource = n_lst;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
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
                List<WorkRecode_VO> w_lst = (List<WorkRecode_VO>)dataGridView1.DataSource;
                bool bResult = P_Service.FinishRecode(D_lst, w_lst);
                List<WorkRecode_VO> n_lst = P_Service.GetWork();
                dataGridView2.DataSource = n_lst;
                if (bResult)
                {
                    MessageBox.Show("등록 성공");
                }
                else
                {
                    MessageBox.Show("등록 실패");
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void btnEX_Click(object sender, EventArgs e)
        {

            using (frmWaitForm frm = new frmWaitForm(ExcelDown))
            {
                frm.ShowDialog(this);
            }

        }

        private void ExcelDown()
        {
            try
            {
                Excel.Application excel = new Excel.Application
                {
                    Visible = true
                };

                string filename = "test" + ".xlsx";

                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
                //byte[] temp = Properties.Resources.order;

                //System.IO.File.WriteAllBytes(tempPath, temp);

                Excel._Workbook workbook;

                workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);//tempPath

                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dataGridView1.Columns.Count - 3; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count - 3; j++)
                    {
                        try
                        {
                            Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                }

                SetBottomStatusLabel("다운로드가 완료되었습니다.");
            }
            catch (Exception ex)
            {
                LoggingUtility.GetLoggingUtility(ex.Message, Level.Error);
                SetBottomStatusLabel("다운로드에 실패하였습니다.");
            }
        }
    }
}