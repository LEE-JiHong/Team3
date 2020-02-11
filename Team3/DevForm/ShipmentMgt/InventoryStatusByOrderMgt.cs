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
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvStockStatus.Columns.Add(chk);

            Point headerLocation = dgvStockStatus.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheckBox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 2); //그냥 이렇게 주면 위치가 썩 이쁘지않아서 숫자 좀 더 플러스함
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckbox_Click);
            dgvStockStatus.Controls.Add(headerCheckBox);

            //TODO 


           



            GridViewUtil.AddNewColumnToTextBoxGridView(dgvStockStatus, "비고", "", true, 130);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvStockStatus, "이동수량", "", true, 130);

            #region DGV콤보박스
           

            comboBoxColumn.HeaderText = "TO창고";
            comboBoxColumn.Name = "combo";
            
            for (int i = 0; i < _cboFromFac.Count; i++)
            {
                comboBoxColumn.DisplayMember = _cboToFac[i].factory_name;
                comboBoxColumn.ValueMember = _cboToFac[i].factory_id.ToString();
                comboBoxColumn.Items.Add(_cboToFac[i].factory_name);
            }

            dgvStockStatus.Columns.Add(comboBoxColumn);
            dgvStockStatus.Rows.Add();
            dgvStockStatus.AllowUserToAddRows = false;
            #endregion



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
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShipmentVO vo = new ShipmentVO();
            for (int i = 0; i < dgvStockStatus.Rows.Count; i++)
            {
                MessageBox.Show(dgvStockStatus.Rows[i].Cells[1].Value.ToString()); 
                MessageBox.Show(dgvStockStatus.Rows[i].Cells[2].Value.ToString()); 
              // MessageBox.Show(comboBoxColumn.ValueMember.ToString()); 
                
            }


               // MessageBox.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
