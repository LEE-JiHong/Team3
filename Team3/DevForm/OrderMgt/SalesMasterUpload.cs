using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Team3
{
    public partial class SalesMasterUpload : DgvBaseForm
    {
        public SalesMasterUpload()
        {
            InitializeComponent();
        }

        private void SalesMasterUpload_Load(object sender, EventArgs e)
        {
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "planDate", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "순번", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "WORK_ORDER_ID", "", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "업체코드", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납품처", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "MKT", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주구분", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "GROUP", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "구분", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "SIZE", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고P/NO", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "계획수량합계", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납기일", "", true);
        }

        //엑셀 등록 버튼
        private void btnAddExcel_Click(object sender, EventArgs e)
        {
            // 엑셀 변수 선언
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;

            SalesMasterDialog frm = new SalesMasterDialog();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 데이터그리드뷰 클리어
                    dataGridView1.Columns.Clear();

                    // 엑셀데이터를 담을 데이터테이블 선언
                    DataTable dt = new DataTable();

                    // 엑셀 변수들 초기화
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open(frm.FilePath);
                    xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1); // 첫 번째 시트

                    // 시트에서 범위 설정
                    // UsedRange는 사용된 셀 모두이므로 
                    // 범위를 따로 지정하려면 
                    // xlWorksheet.Range[xlWorksheet.Cells[시작 행, 시작 열], xlWorksheet.Cells[끝 행, 끝 열]]
                    Excel.Range range = xlWorksheet.UsedRange;

                    // 2차원 배열에 담기
                    object[,] data = range.Value;

                    // 데이터테이블에 엑셀 칼럼만큼 칼럼 추가
                    for (int i = 1; i <= range.Columns.Count; i++)
                    {
                        //dt.Columns.Add(i.ToString(), typeof(string));
                        dt.Columns.Add(data[1, i].ToString());
                    }

                    // 데이터테이블에 2차원 배열에 담은 엑셀데이터 추가
                    for (int r = 2; r <= range.Rows.Count; r++)
                    {
                        DataRow dr = dt.Rows.Add();

                        for (int c = 1; c <= range.Columns.Count; c++)
                        {
                            dr[c - 1] = data[r, c];
                        }
                    }

                    xlWorkbook.Close(true);
                    xlApp.Quit();

                    // 데이터그리드뷰에 데이터테이블 바인딩
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    // 사용이 끝난 엑셀파일 Release
                    ReleaseExcelObject(xlWorksheet);
                    ReleaseExcelObject(xlWorkbook);
                    ReleaseExcelObject(xlApp);
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

        //양식 다운로드 버튼
        private void btnDownload_Click(object sender, EventArgs e)
        {

        }
    }
}
