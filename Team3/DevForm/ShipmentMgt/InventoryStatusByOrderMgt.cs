using log4net.Core;
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

namespace Team3.DevForm.NewFolder1
{
    public partial class InventoryStatusByOrder : Team3.VerticalGridBaseForm
    {
        List<ShipmentVO> shipment_list;
        CheckBox headerCheckBox = new CheckBox();
        DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
        public InventoryStatusByOrder()
        {
            InitializeComponent();
        }

        private void InventoryStatusByOrder_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now.AddMonths(1);



            List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
            ResourceService resource_service = new ResourceService();
            f_list = resource_service.GetFactoryAll();

            #region From창고cbo
            List<FactoryDB_VO> _cboFromFac = (from item in f_list
                                              where item.facility_value == "FAC400"
                                              select item).ToList();
            ComboUtil.ComboBinding(cboFromFac, _cboFromFac, "factory_code", "factory_name", "선택");
            #endregion

            #region To창고cbo
            List<FactoryDB_VO> _cboToFac = (from item in f_list
                                            where item.facility_value == "FAC700"
                                            select item).ToList();
            ComboUtil.ComboBinding(cboToFac, _cboToFac, "factory_code", "factory_name", "선택");
            #endregion



            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "선택";

            chk.Name = "chk";
            chk.Width = 30;
            dgvStockStatus.Columns.Add(chk);



            //TODO
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "품목", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "납기일", "so_edate", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "잔여수량", "so_pcount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "From창고", "from_wh", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "From창고재고", "w_count_present", true, 100, DataGridViewContentAlignment.MiddleRight);
            #region DGV콤보박스


            comboBoxColumn.HeaderText = "TO창고";
            comboBoxColumn.Name = "combo";


            for (int i = 0; i < _cboToFac.Count; i++)
            {
                comboBoxColumn.DisplayMember = _cboToFac[i].factory_name;
                comboBoxColumn.ValueMember = _cboToFac[i].factory_id.ToString();
                comboBoxColumn.Items.Add(_cboToFac[i].factory_name);

            }
            comboBoxColumn.Items.RemoveAt(0);



            dgvStockStatus.Columns.Add(comboBoxColumn);
            dgvStockStatus.Rows.Add();
            dgvStockStatus.AllowUserToAddRows = false;
            #endregion
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvStockStatus, "비고", "wh_comment", false, 130);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvStockStatus, "이동수량", "transfer_count", true, 130);

            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "so_id", "so_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "업로드날짜", "so_sdate", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "PlanID", "plan_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "고객사코드", "company_code", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "업체유형", "company_type", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "From창고코드", "from_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "품번", "product_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "출고수량", "so_ocount", false, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "취소수량", "so_ccount", false, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "To창고", "to_wh", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "To창고코드", "to_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);
            //GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "수정자", "uadmin", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "To창고이름", "factory_name", false, 100, DataGridViewContentAlignment.MiddleCenter);

            dgvStockStatus.AutoGenerateColumns = false;
            dgvStockStatus.DataSource = shipment_list;
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

            dgvStockStatus.ClearSelection();//전체선택이 풀려있음
        }
        private void copyAlltoClipboard()       //복사기능
        {
            dgvStockStatus.SelectAll();
            DataObject dataObj = dgvStockStatus.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStockStatus.Rows)
            {
                MessageBox.Show(row.Cells["so_id"].Value.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<ShipmentVO> list = new List<ShipmentVO>();
            foreach (DataGridViewRow row in dgvStockStatus.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    ShipmentVO vo = new ShipmentVO();

                    vo.plan_id = row.Cells[12].Value.ToString();

                    if (row.Cells["combo"].Value == null)
                    {
                        continue;
                    }
                    else
                    {
                        vo.factory_name = row.Cells["combo"].Value.ToString();
                    }

                    vo.w_count_present = Convert.ToInt32(row.Cells[9].Value);
                    //vo.uadmin = 1002;
                    vo.udate = DateTime.Now.ToString("yyyy-MM-dd");
                    vo.product_id = Convert.ToInt32(row.Cells[16].Value);
                    vo.category = "P_ORDER_MOVE";

                    list.Add(vo);
                }
            }

            try
            {
                ShipmentService shipment_service = new ShipmentService();
                if (MessageBox.Show($"선택하신 {list.Count}건을 이동처리 하시겠습니까?","이동 처리"
                    ,MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                {
                    bool bResult = shipment_service.TransferProcessing(list);
                    if (bResult)        //이동처리 성공시
                    {
                        SetBottomStatusLabel($"선택하신 {list.Count}건의 이동처리가 완료되었습니다.");
                        btnSelect.PerformClick();
                    }
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                //이동처리 실패시

                SetBottomStatusLabel("이동처리를 할 수 없습니다.");
                {
                    return;
                }

            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //조회 버튼
            try
            {
                InventoryOrderMgtVO vo = new InventoryOrderMgtVO();
                vo.start_date = dtpFromDate.Value.ToShortDateString();
                vo.end_date = dtpToDate.Value.ToShortDateString();

                if (cboFromFac.Text != "선택")
                {
                    vo.fromFactory = cboFromFac.SelectedValue.ToString();
                }

                if (txtProduct.Text != "")
                {
                    vo.product_name = txtProduct.Text.Trim();
                }

                ShipmentService service_shipment = new ShipmentService();
                shipment_list = service_shipment.GetInventoryStatusByOrder(vo);

                dgvStockStatus.DataSource = shipment_list;

                SetBottomStatusLabel($"{shipment_list.Count}건이 조회되었습니다.");
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                SetBottomStatusLabel("다시 검색하세요.");
            }
        }
    }
}
