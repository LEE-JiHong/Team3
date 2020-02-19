using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using log4net.Core;

namespace Team3
{
    public partial class BOR : Team3.VerticalGridBaseForm
    {
        ResourceService service = new ResourceService();
        CommonCodeService common_service;
        List<CommonVO> common_list;
        List<BORDB_VO> list;

        public BOR()
        {
            InitializeComponent();
        }
        private void BOR_Load(object sender, EventArgs e)
        {
            this.ImeMode = ImeMode.Hangul;
            GridViewUtil.SetDataGridView(dataGridView1);
            dgvColumnSet();



            LoadData();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 셀 클릭하면 행 전체가 선택


            common_service = new CommonCodeService();
            common_list = common_service.GetCommonCodeAll();
            {
                //사용유무
                var mCode = (from item in common_list
                             where item.common_type == "route"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboProcess, mCode, "common_value", "common_name", "미선택");
            }


        }

        private void LoadData()
        {
            list = service.GetBORAll();

            dataGridView1.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BORPop frm = new BORPop(BORPop.EditMode.Input);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SetBottomStatusLabel("등록 성공");
                    MessageBox.Show("등록 성공");
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblID.Text != "")
                {
                    BORPop frm = new BORPop(BORPop.EditMode.Update, lblID.Text, lblRoute.Text);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        SetBottomStatusLabel("수정 성공");
                        MessageBox.Show("수정 성공");
                    }
                }
                else
                {
                    SetBottomStatusLabel("선택된 BOR이 없습니다");
                    MessageBox.Show("선택된 BOR이 없습니다.");
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lblRoute.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(ExcelLoad))
            {
                frm.ShowDialog(this);
            }
        }
        public void ExcelLoad()
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
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
    

    private void btnDel_Click(object sender, EventArgs e)
    {
        ResourceService R_service = new ResourceService();
        try
        {
            DialogResult dr = MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " 를(을) 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                R_service = new ResourceService();
                bool bResult = R_service.DeleteBOR(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));

                if (bResult)
                {
                    LoadData();
                    SetBottomStatusLabel("삭제완료");
                    MessageBox.Show("삭제완료");

                }
                else if (!bResult)
                {
                    SetBottomStatusLabel("삭제실패");
                    MessageBox.Show("삭제 실패");
                    return;
                }
            }
        }
        catch (Exception err)
        {
            string str = err.Message;
            LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {

        dataGridView1.Columns.Clear();
        BORDB_VO vo = new BORDB_VO();
        vo.product_name = txtItem.Text;
        if (cboProcess.Text == "미선택")
        {
            vo.common_name = "";
        }
        else
            vo.common_name = cboProcess.Text;
        vo.m_name = txtFacility.Text;

        List<BORDB_VO> list = service.BOR_Search(vo);
        if (list == null)
        {

            return;
        }
        else
        {
            dataGridView1.DataSource = null;
            dgvColumnSet();
            dataGridView1.DataSource = list;
        }

        if (dataGridView1.Rows.Count <= 0)
        {
            SetBottomStatusLabel("조회에 실패하였습니다. 다시 시도하여 주십시오.");
        }
        else
        {
            SetBottomStatusLabel("조회가 완료되었습니다.");
        }
    }

    private void dgvColumnSet()
    {
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "ID", "bor_id", false);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "bom_id", "bom_id", false);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "공정", "common_type", false);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "공정명", "common_name", true);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비", "m_code", true);

        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "설비명", "m_name", true);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "Tack Time", "bor_tacktime", true);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "공정선행시간", "bor_readytime", true);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "사용유무", "bor_yn", false);
        GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "비고", "bor_comment", true);
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadData();
        foreach (Control ctrl in panel1.Controls)
        {
            if (typeof(TextBox) == ctrl.GetType())
            {
                ctrl.Text = "";
            }
        }

        foreach (Control con in panel1.Controls)
        {
            if (con is ComboBox cb)
            {
                cb.SelectedIndex = 0;

            }
        }
    }
}
}