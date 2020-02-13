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





            DataTable dt = new DataTable();
            ShipmentService service_shipment = new ShipmentService();
            shipment_list = service_shipment.GetInventoryStatusByOrder();


            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "선택";

            chk.Name = "chk";
            chk.Width = 30;
            dgvStockStatus.Columns.Add(chk);

            //Point headerLocation = dgvStockStatus.GetCellDisplayRectangle(0, -1, true).Location;

            //headerCheckBox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            //headerCheckBox.BackColor = Color.White;
            //headerCheckBox.Size = new Size(18, 18);
            //headerCheckBox.Click += new EventHandler(HeaderCheckbox_Click);
            //dgvStockStatus.Controls.Add(headerCheckBox);

            //TODO 
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "so_id", "so_id", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "출고수량", "so_ocount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "취소수량", "so_ccount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "잔여수량", "so_pcount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "From창고재고", "w_count_present", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "납기일", "so_edate", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "업로드날짜", "so_sdate", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "PlanID", "plan_id", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "고객사코드", "company_code", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "업체유형", "company_type", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "품목", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "From창고", "from_wh", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "From창고코드", "from_wh_value", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "품번", "product_id", true, 100, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "To창고", "to_wh", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "To창고코드", "to_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "수정자", "uadmin", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvStockStatus, "To창고이름", "factory_name", false, 100, DataGridViewContentAlignment.MiddleCenter);



            GridViewUtil.AddNewColumnToTextBoxGridView(dgvStockStatus, "비고", "wh_comment", true, 130);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvStockStatus, "이동수량", "transfer_count", true, 130);


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

            //dgvStockStatus.AutoGenerateColumns = false;

            dgvStockStatus.DataSource = shipment_list;


        }
        private void HeaderCheckbox_Click(object sender, EventArgs e)
        {
            dgvStockStatus.EndEdit();

            foreach (DataGridViewRow row in dgvStockStatus.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox.Checked;
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

            dgvStockStatus.ClearSelection();//전체선택이 풀려있음
        }
        private void copyAlltoClipboard()       //복사기능
        {
            dgvStockStatus.SelectAll();
            DataObject dataObj = dgvStockStatus.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void dgvStockStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvStockStatus.Rows.Count; i++)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShipmentVO vo = new ShipmentVO();
            for (int i = 0; i < dgvStockStatus.Rows.Count; i++)
            {
                //MessageBox.Show(dgvStockStatus.Rows[i].Cells[1].Value.ToString()); 
                //MessageBox.Show(dgvStockStatus.Rows[i].Cells[2].Value.ToString()); 
               
                if (dgvStockStatus.Rows[i].Cells["combo"].Value == null)
                {
                    continue;
                }
                else
                {
                    MessageBox.Show(dgvStockStatus.Rows[i].Cells["combo"].Value.ToString());
                }
                //MessageBox.Show(dgvStockStatus.SelectedRows.Count.ToString()); 

            }



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ShipmentVO _shipvo = new ShipmentVO();
            foreach (DataGridViewRow row in this.dgvStockStatus.SelectedRows)
            {
                _shipvo = row.DataBoundItem as ShipmentVO;
            }
            ShipmentService shipment_service = new ShipmentService();
            int count = dgvStockStatus.SelectedRows.Count;
            if (MessageBox.Show($"선택하신 {count}건을 이동처리 하시겠습니까?") == DialogResult.OK)
            {
                ShipmentVO vo = new ShipmentVO();
                vo.plan_id = _shipvo.plan_id;

                for (int i = 0; i < dgvStockStatus.Rows.Count; i++)
                {
                    if (dgvStockStatus.Rows[i].Cells["combo"].Value == null)
                    {
                        continue;
                    }
                    else
                    {
                        //MessageBox.Show(dgvStockStatus.Rows[i].Cells["combo"].Value.ToString());
                        vo.factory_name = dgvStockStatus.SelectedRows[i].Cells["combo"].Value.ToString();
                    }



                    //vo.factory_name = dgvStockStatus.SelectedRows[i].Cells["combo"].Value.ToString();
                   
                }
              








                vo.w_count_present = _shipvo.transfer_count;
                vo.uadmin = 1002;
                vo.wh_comment = _shipvo.wh_comment;
                vo.udate = DateTime.Now.ToString("yyyy-MM-dd");
                vo.product_id = _shipvo.product_id;
                vo.category = "P_ORDER_MOVE";
                bool bResult = shipment_service.TransferProcessing(vo);
                if (bResult)        //이동처리 성공시
                {
                    SetBottomStatusLabel($"선택하신 {count}건의 이동처리가 완료되었습니다.");
                }
                else            //이동처리 실패시
                {
                    MessageBox.Show("등록실패 , 다시시도 하세요");
                    return;
                }
            }
        }
    }
}
