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


namespace Team3
{
    public partial class BomMgt : Team3.HorizonGridBaseForm
    {
        CommonCodeService common_service;
        List<CommonVO> codelist;
        BomService bom_service;
        List<BomVO> BOM_list;
        public BomMgt()
        {
            InitializeComponent();
          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BomPop frm = new BomPop(BomPop.EditMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bom_service = new BomService();
                List<BomVO> newBOMlist = bom_service.GetBomAll();    //등록후 다시 조회
                dgvBom.DataSource = newBOMlist;
                dgvBom.ClearSelection();
                SetBottomStatusLabel("신규 BOM이 등록되었습니다.");
            }
        }

        private void BomMgt_Load(object sender, EventArgs e)
        {
            LoadDGV();
            dgvBom.ClearSelection();
            ComboBinding();
        }
        private void LoadDGV()
        {
        
            BomService service = new BomService();
            BOM_list = service.GetBomAll();

            dgvBom.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBom.Columns.Add("Number", "No.");
            dgvBom.Columns[0].Width = 53;
            dgvBom.Columns[0].Visible = false;

            #region DGV바인딩
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품목유형", "bom_type", true, 130,DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품목", "bom_codename", true, 150, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품명", "bom_name", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "단위", "bom_unit", true, 100, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "사용여부", "bom_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "소요계획", "plan_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "시작일", "bom_sdate", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "종료일", "bom_edate", true, 130, DataGridViewContentAlignment.MiddleRight);
            //GridViewUtil.AddNewColumnToDataGridView(dgvBom, "수정자", "bom_uadmin", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "수정일", "bom_udate", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "비고", "bom_comment", true, 150, DataGridViewContentAlignment.MiddleLeft); 
            #endregion

            #region visible_false
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품번", "product_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "BOM레벨", "bom_level", false, 80, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "소요량", "bom_use_count", false, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "BomID", "bom_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "상위품목", "bom_parent_id", false, 130);
            #endregion
            GridViewUtil.SetDataGridView(dgvBom);
            dgvBom.AutoGenerateColumns = false;
            dgvBom.DataSource = BOM_list;
            dgvBom.ClearSelection();

        }

     
        private void ComboBinding()
        {
            common_service = new CommonCodeService();
            codelist = common_service.GetCommonCodeAll();
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.common_type == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "common_value", "common_name", "선택");
        }

        private void dgvBom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBomDetail.DataSource = null;
            dgvBomDetail.Columns.Clear();
            //dgvBom[11, dgvBom.CurrentRow.Index].Value.ToString()
            bom_service = new BomService();
            List<BomVO> bomDetail = bom_service.GetBomAll(Convert.ToInt32(dgvBom[11, dgvBom.CurrentRow.Index].Value) );

            dgvBomDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBomDetail.Columns.Add("Number", "No.");
            dgvBomDetail.Columns[0].Width = 53;
            dgvBomDetail.Columns[0].Visible = false;

            #region DGV바인딩
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "상위품목", "bom_parent_codename", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "품목", "bom_codename", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "품명", "bom_name", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "품목유형", "bom_type", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "단위", "bom_unit", true, 78, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "소요량", "bom_use_count", true, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "BOM레벨", "bom_level", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "시작일", "bom_sdate", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "종료일", "bom_edate", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "사용여부", "bom_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "소요계획", "plan_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "수정자", "bom_uadmin", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "수정일", "bom_udate", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "비고", "bom_comment", true, 130, DataGridViewContentAlignment.MiddleCenter); 
            #endregion

            #region visible_false
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "품번", "product_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "BomID", "bom_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            #endregion
            dgvBomDetail.AutoGenerateColumns = false;
            dgvBomDetail.DataSource = bomDetail;
            dgvBomDetail.ClearSelection();

        }

        private void dgvBomDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvBomDetail.SelectedRows)
            {
                BomVO vo = new BomVO();
                vo = row.DataBoundItem as BomVO;
                if (vo.bom_typevalue == "RM" )
                {
                    BomPop frm = new BomPop(BomPop.EditMode.Update, vo);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        bom_service = new BomService();
                        List<BomVO> newBOMlist = bom_service.GetBomAll();    //등록후 다시 조회
                        dgvBom.DataSource = newBOMlist;
                        dgvBom.ClearSelection();
                        SetBottomStatusLabel("BOM 수정이 완료되었습니다.");
                    }
                    SetBottomStatusLabel("원자재는 선택할 수 없습니다.");
                    return;
                }
            }



            int product_id = Convert.ToInt32( dgvBomDetail[15, dgvBomDetail.CurrentRow.Index].Value);
            bom_service = new BomService();

            List<BomVO> newBom = bom_service.GetBomAll(0, product_id);
            dgvBom.DataSource = null;
            dgvBom.Columns.Clear();

            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품목유형", "bom_type", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품목", "bom_codename", true, 150, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품명", "bom_parent_name", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "단위", "bom_unit", true, 100, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "사용여부", "bom_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "소요계획", "plan_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "시작일", "bom_sdate", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "종료일", "bom_edate", true, 130, DataGridViewContentAlignment.MiddleRight);
            //GridViewUtil.AddNewColumnToDataGridView(dgvBom, "수정자", "bom_uadmin", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "수정일", "bom_udate", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "비고", "bom_comment", true, 150, DataGridViewContentAlignment.MiddleLeft);


            #region visible_false
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품번", "product_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "BOM레벨", "bom_level", false, 80, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "소요량", "bom_use_count", false, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "BomID", "bom_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "상위품목", "bom_parent_id", false, 130);
            #endregion
            dgvBom.AutoGenerateColumns = false;
            dgvBom.DataSource = newBom;
            dgvBom.ClearSelection();

            int bom_id = Convert.ToInt32(dgvBomDetail[15, dgvBomDetail.CurrentRow.Index].Value) ;
            List<BomVO> newBomDetail = bom_service.GetBomAll(0,bom_id);

            dgvBomDetail.DataSource = null;
            dgvBomDetail.Columns.Clear();

            dgvBomDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBomDetail.Columns.Add("Number", "No.");
            dgvBomDetail.Columns[0].Width = 53;
            dgvBomDetail.Columns[0].Visible = false;

            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "상위품목", "bom_parent_name", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "품목", "bom_codename", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "품명", "bom_name", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "품목유형", "bom_type", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "단위", "bom_unit", true, 78, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "소요량", "bom_use_count", true, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "BOM레벨", "bom_level", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "시작일", "bom_sdate", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "종료일", "bom_edate", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "사용여부", "bom_yn", true, 120, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "소요계획", "plan_yn", true, 120, DataGridViewContentAlignment.MiddleCenter);
            //GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "수정자", "bom_uadmin", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "수정일", "bom_udate", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "비고", "bom_comment", true, 130, DataGridViewContentAlignment.MiddleCenter);

            #region visible_false
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "품번", "product_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBomDetail, "BomID", "bom_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            #endregion

            dgvBomDetail.AutoGenerateColumns = false;
            dgvBomDetail.DataSource = newBomDetail;
            dgvBomDetail.ClearSelection();
            SetBottomStatusLabel("BOM을 선택하세요");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //ProductVO product_vo = new ProductVO();
            BomVO vo = new BomVO();
            foreach (DataGridViewRow row in this.dgvBom.SelectedRows)
            {
                vo = row.DataBoundItem as BomVO;
            }

            BomPop frm = new BomPop(BomPop.EditMode.Update, vo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bom_service = new BomService();
                List<BomVO> newBOMlist = bom_service.GetBomAll();    //등록후 다시 조회
                dgvBom.DataSource = newBOMlist;
                dgvBom.ClearSelection();
                SetBottomStatusLabel("BOM 수정이 완료되었습니다.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
         
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string searchName = txtProduct.Text;
            List<BomVO> searchList;

            //발주 대기 리스트 검색

            if (searchName.Length < 1)
            {
                dgvBom.DataSource = BOM_list;
            }
            else
            {
                searchList = (from item in BOM_list
                              where item.bom_codename.ToUpper().Contains(searchName.ToUpper())
                              select item).ToList();

                dgvBom.DataSource = searchList;
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();

            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            dgvBom.ClearSelection();//전체선택이 풀려있음
        }
        private void copyAlltoClipboard()       //복사기능
        {
            dgvBom.SelectAll();
            DataObject dataObj = dgvBom.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSelect.PerformClick();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvBom.DataSource = null;
            dgvBomDetail.DataSource = null;
            foreach (var con in panel1.Controls)
            {
                if(con is TextBox txt)
                {
                    txt.Text = "";
                }
            }
            foreach(var con in panel1.Controls)
            {
                if(con is ComboBox cbo)
                {
                    cbo.SelectedIndex = 0;
                }
            }

            
        }

       
    }
}
