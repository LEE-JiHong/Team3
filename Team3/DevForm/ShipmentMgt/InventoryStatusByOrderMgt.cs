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
            dgvStockStatus.DataSource = shipment_list;
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvStockStatus, "비고", "", true, 130);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvStockStatus, "이동수량", "", true, 130);


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

        
    }
}
