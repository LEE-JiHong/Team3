using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3
{
    public partial class FactoryMgt : Team3.VerticalGridBaseForm
    {
        ResourceService service = new ResourceService();
        List<CommonVO> common_list;
        List<FactoryDB_VO> list;

        public FactoryMgt()
        {
            InitializeComponent();
        }
        private void FactoryMgt_Load(object sender, EventArgs e)
        {
            list = service.GetFactoryAll();
            dataGridView1.DataSource = list;

            CommonCodeService Common_service = new CommonCodeService();
            common_list = Common_service.GetCommonCodeAll();

            var mCode = (from item in common_list
                         where item.common_type == "facility_class_id"
                         select item).ToList();
            ComboUtil.ComboBinding<CommonVO>(cboSearchFacilityGroup, mCode, "common_value", "common_name", "미선택");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FactoryPop frm = new FactoryPop(FactoryPop.EditMode.Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                list = service.GetFactoryAll();
                dataGridView1.DataSource = list;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "")
            {
                FactoryPop frm = new FactoryPop(FactoryPop.EditMode.Update, lblID.Text);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    list = service.GetFactoryAll();
                    dataGridView1.DataSource = list;
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {


            try
            {
                DialogResult dr = MessageBox.Show(dataGridView1.CurrentRow.Cells[5].Value.ToString() + " 를(을) 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    bool bResult = service.DelelteFactory(Convert.ToInt32(lblID.Text));
                    if (bResult)
                    {
                        MessageBox.Show("삭제완료");
                    }
                    else if (!bResult)
                    {
                        MessageBox.Show("삭제 실패");
                        return;
                    }
                }
            }
            catch (Exception err)
            {
                string sr = err.Message;
            }
        }

        private void FactoryMgt_Activated(object sender, EventArgs e)
        {


        }

        private void btnEx_Click(object sender, EventArgs e)
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
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count; j++)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
