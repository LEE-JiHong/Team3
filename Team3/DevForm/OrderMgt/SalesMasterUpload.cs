using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3
{
    public partial class SalesMasterUpload : DgvBaseForm
    {
        string versionName;

        public SalesMasterUpload()
        {
            InitializeComponent();
        }

        private void SalesMasterUpload_Load(object sender, EventArgs e)
        {
            versionName = DateTime.Now.ToShortDateString().Replace("-", "") + "_P";

            SetDataGrid();
        }

        //데이터그리드뷰 칼럼 세팅
        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "planDate", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "순번", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "WORK_ORDER_ID", "", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "업체코드", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납품처", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고P/NO", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "계획수량합계", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납기일", "", true);
        }

        //엑셀 등록 버튼
        private void btnAddExcel_Click(object sender, EventArgs e)
        {
            SalesMasterDialog frm = new SalesMasterDialog();

            try
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    versionName = frm.PlanVersion;

                    OrderService service = new OrderService();

                    int resultNum = service.GetPlanIDINSOMaster(versionName);

                    if (resultNum > 0)
                    {
                        if (MessageBox.Show("기존 계획기준 버전이 존재합니다. 계속 진행하시겠습니까?", "계획기준버전확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            dataGridView1.Columns.Clear();
                            dataGridView1.DataSource = frm.Data;
                            SetBottomStatusLabel("엑셀 업로드가 완료되었습니다.");
                        }
                    }
                    else
                    {
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = frm.Data;
                        SetBottomStatusLabel("엑셀 업로드가 완료되었습니다.");
                    }
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        //양식 다운로드 버튼
        private void btnDownload_Click(object sender, EventArgs e)
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

                Excel._Workbook workbook;

                workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);//tempPath

                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                int StartCol = 0;
                int StartRow = 1;
                int j = 0;

                //Write Headers
                for (j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                SetBottomStatusLabel("양식 다운로드가 완료되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //영업마스터 생성
        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("파일 업로드는 필수입니다.");
                SetBottomStatusLabel("파일 업로드는 필수입니다.");
            }
            else
            {
                List<SOMasterVO> list = new List<SOMasterVO>();

                for (int i = 0; i<dataGridView1.Rows.Count; i++)
                {
                    SOMasterVO vo = new SOMasterVO();
                    vo.plan_id = versionName;
                    vo.so_wo_id = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    vo.so_pcount = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                    vo.company_code = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    vo.so_edate = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    vo.so_sdate = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    vo.product_name = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    list.Add(vo);
                }

                //DB
                OrderService service = new OrderService();
                bool result = service.AddSOMaster(list);

                if (result)
                {
                    Form fc = Application.OpenForms["Main"];
                    Main frm = (Main)fc;

                    frm.GetForm("영업마스터");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("영업마스터 생성에 실패하였습니다. 다시 시도하여주십시오.");
                    SetBottomStatusLabel("영업마스터 생성에 실패하였습니다. 다시 시도하여주십시오.");
                    return;
                }
            }
        }
    }
}
