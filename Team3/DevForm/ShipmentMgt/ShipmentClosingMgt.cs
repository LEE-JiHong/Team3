﻿using log4net.Core;
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
        int price_present = 0;
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
            SetDGV();
            SetCbo();

        }
        private void SetCbo()
        {
            List<CompanyVO> company_list = new List<CompanyVO>();
            OrderService order_service = new OrderService();
            company_list = order_service.GetCompanyAll("COOPERATIVE");
            ComboUtil.ComboBinding(cboCustomer, company_list, "company_code", "company_name", "선택");
        }

        private void SetDGV()
        {
            shipment_service = new ShipmentService();
            List<ShipmentOutVO> shipmentlist = shipment_service.GetClientOrder();

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "선택";

            chk.Name = "chk";
            chk.Width = 40;
            dgvClientOrder.Columns.Add(chk);


            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "so_wo_id", true, 180, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사코드", "company_code", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사", "company_name", true, 160, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품목", "product_codename", true, 150, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품명", "product_name", true, 190, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "주문수량", "so_pcount", true, 100, DataGridViewContentAlignment.MiddleRight);

            //TODO 쿼리수정
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "주문가능수량", "orderable_count", true, 150, DataGridViewContentAlignment.MiddleRight);

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감수량", "so_ocount", true, 100, DataGridViewContentAlignment.MiddleRight, true);

            GridViewUtil.AddNewColumnToTextBoxGridView(dgvClientOrder, "매출확정수량", "s_count", true, 150, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "매출확정금액", "s_TotalPrice", true, 150, DataGridViewContentAlignment.MiddleRight, true);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감일자", "s_date", true, 128, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품번", "product_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "so_id", "so_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "취소수량", "so_ccount", false, 100, DataGridViewContentAlignment.MiddleRight);

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고이름", "w_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "납기일", "so_edate", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고", "from_wh", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고재고", "w_count_present", false, 100, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToTextBoxGridView(dgvClientOrder, "비고", "wh_comment", false, 130);



            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "업로드날짜", "so_sdate", false, 100, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "업체유형", "company_type", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "From창고코드", "from_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고", "to_wh", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고코드", "to_wh_value", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "수정자", "uadmin", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "To창고이름", "factory_name", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "plan_id", false, 100, DataGridViewContentAlignment.MiddleCenter);

            dgvClientOrder.AutoGenerateColumns = false;
            dgvClientOrder.DataSource = shipmentlist;
            GridViewUtil.SetDataGridView(dgvClientOrder);

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

                    vo.so_id = Convert.ToInt32(row.Cells[13].Value);
                    vo.product_id = Convert.ToInt32(row.Cells[12].Value);
                    vo.plan_id = row.Cells[27].Value.ToString();
                    //vo.product_codename = row.Cells[3].Value.ToString();
                    vo.s_count = Convert.ToInt32(row.Cells[9].Value);
                    vo.company_code = row.Cells[2].Value.ToString();
                    vo.s_date = row.Cells[11].Value.ToString();
                    vo.s_totalprice = Convert.ToDecimal(row.Cells[10].Value);
                    //vo.so_pcount = Convert.ToInt32(row.Cells[4].Value);
                    //vo.w_count_present = Convert.ToInt32(row.Cells[9].Value);
                    //vo.uadmin = 1002;
                    //vo.wh_comment = (row.Cells[8].Value == null) ? "" : row.Cells[8].Value.ToString();
                    //vo.udate = DateTime.Now.ToString("yyyy-MM-dd");

                    //vo.category = "P_SALES_COMPLETE";

                    list.Add(vo);
                }
            }

            try
            {
                ShipmentService shipment_service = new ShipmentService();
                if (MessageBox.Show($"선택하신 {list.Count}건을 마감처리 하시겠습니까?", "마감 처리"
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    bool bResult = shipment_service.EndProcessing(list);
                    if (bResult)        //마감처리 성공시
                    {

                        SetDGV();
                        SetBottomStatusLabel($"선택하신 {list.Count}건의 마감처리가 완료되었습니다.");
                    }
                }
            }
            catch (Exception err)
            {
                //이동처리실패
                SetBottomStatusLabel("마감처리에 실패하였습니다. 다시시도 하세요");
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                return;
            }
        }
        private void dgvClientOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            shipment_service = new ShipmentService();
            price_present = shipment_service.GetPresentPrice(Convert.ToInt32(dgvClientOrder[12, dgvClientOrder.CurrentRow.Index].Value));

            GridViewUtil.SetDgvTextBoxColor(dgvClientOrder, 9);
        }



        private void dgvClientOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                dgvClientOrder[10, dgvClientOrder.CurrentRow.Index].Value =
                    Convert.ToDecimal(dgvClientOrder[9, dgvClientOrder.CurrentRow.Index].Value) * price_present;

                if (Convert.ToInt32(dgvClientOrder[10, dgvClientOrder.CurrentRow.Index].Value) == 0)
                {
                    dgvClientOrder[11, dgvClientOrder.CurrentRow.Index].Value = null;
                }
                else
                {
                    dgvClientOrder[11, dgvClientOrder.CurrentRow.Index].Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
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
