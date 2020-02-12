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
        List<CompanyDB_VO> lst;
        List<CommonVO> common_list;
        ResourceService R_service;
        CommonCodeService common_service;
        public businessMgt()
        {
            InitializeComponent();
        }

        ResourceService service = new ResourceService();
        private void businessMgt_Load(object sender, EventArgs e)
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업체ID", "company_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업체코드", "company_code", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업체명", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업체타입", "common_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업체타입", "company_type", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "대표자명", "company_ceo", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "사업자등록번호", "company_cnum", true);

            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업종", "company_btype", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업태", "company_gtype", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "담당자", "user_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "담당자id", "user_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "이메일", "company_email", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "전화번호", "company_phone", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "팩스", "company_fax", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "수정자", "company_uadmin", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "수정시간", "company_udate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업체정보", "company_comment", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "사용유무", "company_yn", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView2, "업체발주코드", "company_order_code", false);
            GridViewUtil.SetDataGridView(dataGridView2);

            LoadData();

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

        private void LoadData()
        {
            lst = service.GetCompanyAll();
            dataGridView2.DataSource = lst;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CompanyPop frm = new CompanyPop(CompanyPop.EditMode.Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {

                LoadData();
                MessageBox.Show("신규 거래처 등록 성공");
                SetBottomStatusLabel("신규 거래처 등록 성공");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "")
            {
                MessageBox.Show("변경할 업체를 선택해주세요");
                return;
            }
            CompanyPop frm = new CompanyPop(CompanyPop.EditMode.Update, lblID.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("거래처 정보 수정 성공");
                SetBottomStatusLabel("거래처 정보 수정 성공");
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

        private void btnDel_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dr = MessageBox.Show(dataGridView2.CurrentRow.Cells[2].Value.ToString() + " 를(을) 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    R_service = new ResourceService();
                    bool bResult = R_service.DeleteCompany(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value));

                    if (bResult)
                    {
                        MessageBox.Show("삭제완료");
                        SetBottomStatusLabel("거래처 삭제완료");
                    }
                    else if (!bResult)
                    {
                        MessageBox.Show("삭제 실패");
                        SetBottomStatusLabel("삭제실패");
                        return;
                    }
                }
            }
            catch (Exception err)
            {
                string str = err.Message;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = service.GetCompanyAll();
            // 코드만 입력

            if (txtCodeCompany.Text != "")
            {   //이름+
                if (txtNameCompany.Text != "")
                { //사업자번호 +
                    if (txtLicenseNum.Text != "")
                    {
                        var A_code = (from code in lst
                                      where code.company_code.Contains(txtCodeCompany.Text) && code.company_name.Contains(txtNameCompany.Text)
                                      && code.company_cnum.Contains(txtLicenseNum.Text)
                                      select code).ToList();
                        dataGridView2.DataSource = A_code;
                    }
                    //코드 + 이름
                    var c_code = (from code in lst
                                  where code.company_code.Contains(txtCodeCompany.Text) && code.company_name.Contains(txtNameCompany.Text)
                                  select code).ToList();
                    dataGridView2.DataSource = c_code;
                }

                else if (txtLicenseNum.Text != "")
                {
                    var c_code = (from code in lst
                                  where code.company_code.Contains(txtCodeCompany.Text) && code.company_cnum.Contains(txtLicenseNum.Text)
                                  select code).ToList();
                    dataGridView2.DataSource = c_code;
                }

                else if (cboTypeCompany.Text != "미선택")
                {
                    var c_code = (from code in lst
                                  where code.company_code.Contains(txtCodeCompany.Text) && code.company_type.Contains(cboTypeCompany.SelectedValue.ToString())
                                  select code).ToList();
                    dataGridView2.DataSource = c_code;
                }

                else
                {
                    var c_code = (from code in lst
                                  where code.company_code.Contains(txtCodeCompany.Text)
                                  select code).ToList();
                    dataGridView2.DataSource = c_code;
                }
            }
            //이름만 입력
            else if (txtNameCompany.Text != "")
            {
                var c_code = (from code in lst
                              where code.company_name.Contains(txtNameCompany.Text)
                              select code).ToList();
                dataGridView2.DataSource = c_code;
            }
            //사업자번호만 입력
            else if (txtLicenseNum.Text != "")
            {
                var c_code = (from code in lst
                              where code.company_cnum.Contains(txtLicenseNum.Text)
                              select code).ToList();
                dataGridView2.DataSource = c_code;
            }
            //타입만 선택
            else if (cboTypeCompany.Text != "미선택")
            {
                var c_code = (from code in lst
                              where code.company_type.Contains(cboTypeCompany.SelectedValue.ToString())
                              select code).ToList();
                dataGridView2.DataSource = c_code;
            }


            //코드, 이름, 사업자 번호 입력
            if (txtCodeCompany.Text != "" && txtNameCompany.Text != "" && txtLicenseNum.Text != "")
            {
                var c_code = (from code in lst
                              where code.company_code.Contains(txtCodeCompany.Text) && code.company_name.Contains(txtNameCompany.Text)
                              && code.company_cnum.Contains(txtLicenseNum.Text)
                              select code).ToList();
                dataGridView2.DataSource = c_code;
            }
            //모두 입력
            if (txtCodeCompany.Text != "" && txtNameCompany.Text != "" && txtLicenseNum.Text != "" && (cboTypeCompany.Text != "미선택"))
            {
                var c_code = (from code in lst
                              where code.company_code.Contains(txtCodeCompany.Text) && code.company_name.Contains(txtNameCompany.Text)
                              && code.company_cnum.Contains(txtLicenseNum.Text) && code.company_type.Contains(cboTypeCompany.SelectedValue.ToString())
                              select code).ToList();
                dataGridView2.DataSource = c_code;

            }
            else if (txtCodeCompany.Text == "" && txtNameCompany.Text == "" && txtLicenseNum.Text == "" && (cboTypeCompany.Text == "미선택"))
            {
                dataGridView2.DataSource = lst;
            }

        }
    }
}