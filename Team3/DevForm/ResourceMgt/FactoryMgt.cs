using log4net.Core;
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

            this.ImeMode = ImeMode.Hangul;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "ID", "factory_id", false, 60);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "시설군", "facility_class", true, 80);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "시설구분", "facility_type", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "시설타입", "facility_value", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "시설코드", "factory_code", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "시설명", "factory_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "상위시설", "factory_parent", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "업체명", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "사용유무", "factory_yn", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수정자", "factory_uadmin", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수정시간", "factory_udate", true);
            GridViewUtil.SetDataGridView(dataGridView1);
            LoadData();
            CommonCodeService Common_service = new CommonCodeService();
            common_list = Common_service.GetCommonCodeAll();

            var mCode = (from item in common_list
                         where item.common_type == "facility_class_id"
                         select item).ToList();
            ComboUtil.ComboBinding<CommonVO>(cboSearchFacilityGroup, mCode, "common_value", "common_name", "미선택");

            panel1.Focus();
            dataGridView1.CurrentCell = null;

            dataGridView1.ClearSelection();
        }

        private void LoadData()
        {
            list = service.GetFactoryAll();
            dataGridView1.DataSource = list;
            dataGridView1.CurrentCell = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FactoryPop frm = new FactoryPop(FactoryPop.EditMode.Input);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SetBottomStatusLabel("성공적으로 등록되었습니다.");
                }
                else
                    SetBottomStatusLabel("등록실패.");
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
                    FactoryPop frm = new FactoryPop(FactoryPop.EditMode.Update, lblID.Text);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        SetBottomStatusLabel("성공적으로 수정되었습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("선택된 창고 정보가 없습니다.");
                    SetBottomStatusLabel("선택된 창고 정보가 없습니다.");
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
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
                        LoadData();
                        SetBottomStatusLabel(dataGridView1.CurrentRow.Cells[5].Value.ToString() + " 이 삭제 되었습니다.");
                    }
                    else if (!bResult)
                    {
                        MessageBox.Show("삭제 실패");
                        SetBottomStatusLabel("삭제 실패");
                        return;
                    }
                }
            }
            catch (Exception err)
            {

                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }




        private void btnEx_Click(object sender, EventArgs e)
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

                string filename = this.Tag.ToString() + ".xlsx"; // ++ 파일명 변경 

                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
                //byte[] temp = Properties.Resources.;

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

                LoggingUtility.GetLoggingUtility(ex.Message, Level.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //콤보박스 미선택
                if (cboSearchFacilityGroup.SelectedIndex == 0)
                {
                    var fine = (from findCode in list
                                where findCode.factory_code.Contains(txtSearchFacility.Text) || findCode.factory_name.Contains(txtSearchFacility.Text)

                                select findCode).ToList();
                    dataGridView1.DataSource = fine;
                }
                //콤보박스 선택 텍스트 미입력
                else if (cboSearchFacilityGroup.SelectedIndex != 0 && txtSearchFacility.Text == "")
                {
                    var fine = (from findCode in list
                                where findCode.facility_class.Contains(cboSearchFacilityGroup.Text)
                                select findCode).ToList();
                    dataGridView1.DataSource = fine;

                }
                //콤보박스 텍스트 모두입력
                else
                {
                    var fine = (from findCode in list
                                where (findCode.factory_code.Contains(txtSearchFacility.Text) ||
                                findCode.factory_name.Contains(txtSearchFacility.Text))
                                && findCode.facility_class.Contains(cboSearchFacilityGroup.Text)
                                select findCode).ToList();
                    dataGridView1.DataSource = fine;

                }
                if (dataGridView1.Rows.Count < 1)
                {
                    SetBottomStatusLabel("검색 결과가 없습니다");
                }
                dataGridView1.CurrentCell = null;

                if (dataGridView1.Rows.Count <= 0)
                {
                    SetBottomStatusLabel("조회에 실패하였습니다. 다시 시도하여 주십시오.");
                }
                else
                {
                    SetBottomStatusLabel("조회가 완료되었습니다.");
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchFacility.Text = "";
            cboSearchFacilityGroup.SelectedIndex = 0;
            LoadData();
        }
    }
}
