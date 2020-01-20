using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;

namespace Team3
{
    public partial class businessMgt : Team3.VerticalGridBaseForm
    {
        List<CompanyVO> lst;
        List<CommonVO> common_list;
        ResourceService service;
        CommonCodeService common_service;
        public businessMgt()
        {
            InitializeComponent();
        }


        private void businessMgt_Load(object sender, EventArgs e)
        {
            ResourceService service = new ResourceService();
            lst = service.GetCompanyAll();
            dataGridView2.DataSource = lst;

            common_service = new CommonCodeService();
            common_list = common_service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in common_list
                             where item.common_type == "vendor_type"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboTypeCompany, mCode, "common_value", "common_name", "미선택");
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            CompanyPop frm = new CompanyPop(CompanyPop.EditMode.Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CompanyPop frm = new CompanyPop(CompanyPop.EditMode.Update, lblID.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excel = new Excel.Application
                {
                    Visible = true
                };

                string filename = "test" + ".xlsx"; // ++ 파일명 변경 

                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
                //byte[] temp = Properties.Resources.order;

                //System.IO.File.WriteAllBytes(tempPath, temp);

                Excel._Workbook workbook;

                workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);

                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView2.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        try
                        {
                            Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView2[j, i].Value == null ? "" : dataGridView2[j, i].Value;
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
