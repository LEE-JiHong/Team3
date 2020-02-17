using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3.DevForm.ShipmentMgt
{
    public partial class ShipmentClosingMgt : Team3.VerticalGridBaseForm
    {
        ShipmentService shipment_service;
        public ShipmentClosingMgt()
        {
            InitializeComponent();
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

            dgvClientOrder.ClearSelection();//전체선택이 풀려있음
        }
        private void copyAlltoClipboard()       //복사기능
        {
            dgvClientOrder.SelectAll();
            DataObject dataObj = dgvClientOrder.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void ShipmentClosingMgt_Load(object sender, EventArgs e)
        {
            shipment_service = new ShipmentService();
            List<ShipmentOutVO> shipmentlist = shipment_service.GetClientOrder();
           
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "선택";

            chk.Name = "chk";
            chk.Width = 30;
            dgvClientOrder.Columns.Add(chk);


            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "plan_id", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사", "company_name", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품목", "product_codename", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "주문수량", "so_pcount", true, 100, DataGridViewContentAlignment.MiddleRight);
            //GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "주문가능수량", "so_pcount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "취소수량", "so_ccount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감수량", "incount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감확정수량", "incount", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "매출확정금액", "s_TotalPrice", true, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감일자", "s_date", true, 100, DataGridViewContentAlignment.MiddleRight);



            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품번", "product_id", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고이름", "w_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "납기일", "so_edate", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고", "from_wh", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고재고", "w_count_present", false, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvClientOrder, "비고", "wh_comment", false, 130);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvClientOrder, "이동수량", "transfer_count", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "so_id", "so_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "업로드날짜", "so_sdate", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사코드", "company_code", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "업체유형", "company_type", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고코드", "from_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "출고수량", "so_ocount", false, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고", "to_wh", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고코드", "to_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "수정자", "uadmin", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고이름", "factory_name", false, 100, DataGridViewContentAlignment.MiddleCenter);

            dgvClientOrder.AutoGenerateColumns = false;
            dgvClientOrder.DataSource = shipmentlist;
        }
        
        /// <summary>
        /// 마감처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)      
        {
            List<ShipmentOutVO> list = new List<ShipmentOutVO>();
            foreach (DataGridViewRow row in dgvClientOrder.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    ShipmentOutVO vo = new ShipmentOutVO();

                    vo.plan_id = row.Cells[0].Value.ToString();
                    vo.company_name = row.Cells[1].Value.ToString();
                    vo.product_codename = row.Cells[2].Value.ToString();
                    vo.product_name = row.Cells[3].Value.ToString();
                    //vo.s_date = row.Cells[11].Value.ToString();          >>CellLeave이벤트
                    vo.so_pcount = Convert.ToInt32(row.Cells[4].Value);

                    vo.w_count_present = Convert.ToInt32(row.Cells[9].Value);
                    vo.uadmin = 1002;
                    vo.wh_comment = (row.Cells[8].Value == null) ? "" : row.Cells[8].Value.ToString();
                    vo.udate = DateTime.Now.ToString("yyyy-MM-dd");
                    vo.product_id = Convert.ToInt32(row.Cells[16].Value);
                    vo.category = "P_SALES_COMPLETE";

                    list.Add(vo);
                }
            }

            try
            {
                ShipmentService shipment_service = new ShipmentService();
                if (MessageBox.Show($"선택하신 {list.Count}건을 마감처리 하시겠습니까?") == DialogResult.OK)
                {
                    bool bResult = shipment_service.EndProcessing(list);
                    if (bResult)        //마감처리 성공시
                    {
                        SetBottomStatusLabel($"선택하신 {list.Count}건의 마감처리가 완료되었습니다.");
                    }
                    else            //이동처리 실패시
                    {
                        MessageBox.Show("마감실패 , 다시시도 하세요");
                        return;
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }


        }

        private void dgvClientOrder_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
