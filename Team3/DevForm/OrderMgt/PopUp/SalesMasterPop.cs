using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Team3
{
    public partial class SalesMasterDialog : DialogForm
    {
        public SalesMasterDialog()
        {
            InitializeComponent();
        }

        public string FilePath
        {
            get { return txtFilePath.Text; }
            set { txtFilePath.Text = value; }
        }

        DataTable dt;

        public DataTable Data
        {
            get { return dt; }
            set { dt = value; }
        }

        string planID;

        public string PlanID
        {
            get { return planID; }
            set { planID = value; }
        }

        string planVersion;
        public string PlanVersion
        {
            get { return planVersion; }
            set { planVersion = txtPlanVersion.Text; }
        }

        private void SalesMasterDialog_Load(object sender, EventArgs e)
        {

        }

        //엑셀 업로드 버튼
        private void btnFindFile_Click(object sender, EventArgs e)
        {
            // 엑셀 변수 선언
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;

            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "엑셀 파일 (*.xls)|*.xls|엑셀 파일 (*.xlsx)|*.xlsx|모든 파일 (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //filePath = openFileDialog.FileName;

                    txtFilePath.Text = openFileDialog.FileName;

                    FilePath = txtFilePath.Text;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    try
                    {
                        // 데이터그리드뷰 클리어
                        //SetDataGrid();
                        //dataGridView1.Columns.Clear();

                        // 엑셀데이터를 담을 데이터테이블 선언
                        dt = new DataTable();

                        // 엑셀 변수들 초기화
                        xlApp = new Excel.Application();
                        xlWorkbook = xlApp.Workbooks.Open(txtFilePath.Text);
                        xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1); // 첫 번째 시트

                        // 시트에서 범위 설정
                        // UsedRange는 사용된 셀 모두이므로 
                        // 범위를 따로 지정하려면 
                        // xlWorksheet.Range[xlWorksheet.Cells[시작 행, 시작 열], xlWorksheet.Cells[끝 행, 끝 열]]
                        Excel.Range range = xlWorksheet.UsedRange;

                        // 2차원 배열에 담기
                        object[,] data = range.Value;

                        // 데이터테이블에 엑셀 칼럼만큼 칼럼 추가

                        dt.Columns.Add("planDate");
                        for (int i = 1; i <= range.Columns.Count; i++)
                        {
                            //dt.Columns.Add(i.ToString(), typeof(string));
                            dt.Columns.Add(data[1, i].ToString());

                            //planID = data[1, 2].ToString();
                        }

                        // 데이터테이블에 2차원 배열에 담은 엑셀데이터 추가
                        for (int r = 2; r <= range.Rows.Count; r++)
                        {
                            DataRow dr = dt.Rows.Add();
                            for (int c = 1; c <= range.Columns.Count; c++)
                            {
                                dr[0] = dateTimePicker1.Value.ToShortDateString();
                                if (data[r, c].GetType() != typeof(DateTime))
                                {
                                    dr[c] = data[r, c];
                                }
                                else
                                {
                                    dr[c] = Convert.ToDateTime(data[r, c]).ToShortDateString();
                                }
                            }
                        }

                        xlWorkbook.Close(true);
                        xlApp.Quit();

                        // 데이터그리드뷰에 데이터테이블 바인딩
                        //dataGridView1.DataSource = dt;

                    }
                    catch
                    {
                    }
                    finally
                    {
                        // 사용이 끝난 엑셀파일 Release
                        ReleaseExcelObject(xlWorksheet);
                        ReleaseExcelObject(xlWorkbook);
                        ReleaseExcelObject(xlApp);
                    }

                    //계획기준버전
                    txtPlanVersion.Text = dateTimePicker1.Value.ToShortDateString().Replace("-","") + "_P";
                    PlanVersion = txtPlanVersion.Text;
                }
            }
        }

        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        //닫기 버튼
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //날짜 validation 체크
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("현재 날짜보다 작은 날짜는 선택할 수 없습니다.", "날짜 오류");
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        //엑셀파일 업로드하지않은 경우
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dt == null)
            {
                this.DialogResult = DialogResult.Ignore;
                return;
            }
        }
    }
}
