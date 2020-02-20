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
    public partial class ProductMgt : VerticalGridBaseForm
    {
        ProductService product_service;
        CommonCodeService common_service = new CommonCodeService();
        List<CommonVO> codelist;

        public ProductVO vo;
        public ProductVO VO
        {
            get { return vo; }
            set { vo = value; }
        }

        public ProductMgt()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductPop frm = new ProductPop(ProductPop.EditMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                List<ProductVO> new_product_list = product_service.GetAllProducts();    //등록후 다시 조회
                dgvProductList.DataSource = new_product_list;
                SetBottomStatusLabel("신규 품목이 등록되었습니다.");
            }
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            LoadDGV();
            ComboBinding();
        }
        private void LoadDGV()
        {
            dgvProductList.RowHeadersVisible = false;
            //품목 가져오기
            ProductService product_service = new ProductService();
            List<ProductVO> list = product_service.GetAllProducts();
            ProductVO vo = new ProductVO();


            dgvProductList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductList.Columns.Add("Number", "No.");
            dgvProductList.Columns[0].Width = 53;


            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품목유형", "product_type", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품목", "product_codename", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품명", "product_name", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "단위", "product_unit", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "단위수량", "product_unit_count", true, 80, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "발주방식", "product_ordertype", true, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "최소발주수량", "product_lorder_count", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "안전재고수량", "product_safety_count", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "사용여부", "product_yn", true, 78, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "담당자", "product_admin", true, 100);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "입고창고", "product_in_sector", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "출고창고", "product_out", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "납품업체", "product_supply_com", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "발주업체", "product_demand_com", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "측정방식", "product_meastype", true, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "LeadTime", "product_leadtime", true, 80, DataGridViewContentAlignment.MiddleRight);
            #region visible_false
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "최솟값", "product_lsl", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "최댓값", "product_usl", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "아이템코드", "product_itemcode", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품번", "product_id", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "품명코드", "product_code", false, 130);
            
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "수정일", "product_udate", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "비고", "product_comment", false, 130);

            #endregion
            //dgvProductList.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;


            GridViewUtil.SetDataGridView(dgvProductList);
            dgvProductList.AutoGenerateColumns = false;
            dgvProductList.DataSource = list;
        }


        private void SetDgvNumbering(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (Brush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y + 4, drawFormat);
            }
        }
        private void ComboBinding()
        {
            common_service = new CommonCodeService();
            codelist = common_service.GetCommonCodeAll();
            product_service = new ProductService();

            List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
            ResourceService resource_service = new ResourceService();
            f_list = resource_service.GetFactoryAll();

            List<UserVO> user_list = product_service.GetUserAll();

            #region 사용여부cbo
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.common_type == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "common_value", "common_name", "선택");
            #endregion

            #region 품목유형cbo
            _cboUseFlag = (from item in codelist
                           where item.common_type == "item_type"
                           select item).ToList();
            ComboUtil.ComboBinding(cboProductType, _cboUseFlag, "common_value", "common_name", "선택");
            #endregion

            #region 납품업체cbo
            List<CompanyVO> company_list = new List<CompanyVO>();
            OrderService order_service = new OrderService();
            company_list = order_service.GetCompanyAll("customer");
            ComboUtil.ComboBinding(cboCompany, company_list, "company_code", "company_name", "선택");
            #endregion

            #region 발주업체cbo
            company_list = order_service.GetCompanyAll("cooperative");
            ComboUtil.ComboBinding(cboSupplyCompany, company_list, "company_code", "company_name", "선택");

            List<UserVO> user_vo = new List<UserVO>();
            #endregion

            #region 담당자cbo

            ComboUtil.ComboBinding(cboAdmin, user_list, "user_id", "user_name", "선택");
            #endregion

            #region 입고창고cbo
            List<FactoryDB_VO> _cboInSector = (from item in f_list
                                               where item.facility_value == "FAC200"
                                               select item).ToList();
            ComboUtil.ComboBinding(cboInSector, _cboInSector, "factory_code", "factory_name", "선택");
            #endregion

            #region 출고창고cbo
            List<FactoryDB_VO> _cboOutSector = (from item in f_list
                                                where item.facility_value == "FAC100"
                                                select item).ToList();
            ComboUtil.ComboBinding(cboOutSector, _cboOutSector, "factory_code", "factory_name", "선택");
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //vo = new ProductVO();
            ProductVO product_vo = new ProductVO();
            
            foreach (DataGridViewRow row in this.dgvProductList.SelectedRows)
            {
                product_vo = row.DataBoundItem as ProductVO;
            }
            
            ProductPop frm = new ProductPop(ProductPop.EditMode.Update, product_vo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                List<ProductVO> new_product_list = product_service.GetAllProducts();    //등록후 다시 조회
                dgvProductList.DataSource = new_product_list;
                SetBottomStatusLabel("품목 정보가 수정되었습니다.");
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

            dgvProductList.ClearSelection();//전체선택이 풀려있음


        }
        private void ExcelLoad()
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
                for (j = 0; j < dgvProductList.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgvProductList.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dgvProductList.Rows.Count; i++)
                {
                    for (j = 0; j < dgvProductList.Columns.Count; j++)
                    {
                        try
                        {
                            Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dgvProductList[j, i].Value == null ? "" : dgvProductList[j, i].Value;
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

        
        private void copyAlltoClipboard()       //복사기능
        {
            dgvProductList.SelectAll();
            DataObject dataObj = dgvProductList.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void dgvProductList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
          
        }
    }
}
