﻿using DevExpress.XtraReports.UI;
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

namespace Team3.DevForm.ShipmentMgt
{
    public partial class ShipmentClosingStatusMgt : Team3.VerticalGridBaseForm
    {
        ShipmentService shipment_service;
        DataTable dt;
        public ShipmentClosingStatusMgt()
        {
            InitializeComponent();
        }

        private void ShipmentClosingStatusMgt_Load(object sender, EventArgs e)
        {
            List<FactoryDB_VO> f_list = new List<FactoryDB_VO>();
            ResourceService resource_service = new ResourceService();
            f_list = resource_service.GetFactoryAll();

            #region 고객사cbo
            List<CompanyVO> company_list = new List<CompanyVO>();
            OrderService order_service = new OrderService();
            company_list = order_service.GetCompanyAll("COOPERATIVE");
            ComboUtil.ComboBinding(cboCustomer, company_list, "company_code", "company_name", "선택");
            #endregion

          

            //날짜 setting
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            //조회 버튼
            try
            {
                ShipmentClosingVO vo = new ShipmentClosingVO();
                vo.start_date = dtpFromDate.Value.ToShortDateString();
                vo.end_date = dtpToDate.Value.ToShortDateString();

                if (cboCustomer.Text != "선택")
                {
                    vo.company_code = cboCustomer.SelectedValue.ToString();
                }

                if (txtProduct.Text != "")
                {
                    vo.product_name = txtProduct.Text.Trim();
                }

                SetDGV();

                dt = new DataTable();
                shipment_service = new ShipmentService();
                dt = shipment_service.GetSalesCompleteStatus(vo);
                dgvClientOrder.DataSource = dt;
                
                SetBottomStatusLabel($"{dt.Rows.Count}건이 조회되었습니다.");
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void SetDGV()
        {
            dgvClientOrder.Columns.Clear();

            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "so_wo_id", true, 200, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "so_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객주문번호", "plan_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사코드", "s_company", true, 170, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "고객사", "company_name", true, 210, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품목", "product_codename", true, 190, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "품명", "product_name", true, 268, DataGridViewContentAlignment.MiddleLeft);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "주문수량", "so_pcount", true, 125, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감수량", "s_count", true, 125, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "매출액", "s_TotalPrice", true, 170, DataGridViewContentAlignment.MiddleRight, true);
            GridViewUtil.AddNewColumnToDataGridView(dgvClientOrder, "마감일", "s_date", true, 170, DataGridViewContentAlignment.MiddleCenter);

            GridViewUtil.SetDataGridView(dgvClientOrder);

            dgvClientOrder.AutoGenerateColumns = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "조회를 먼저 해야합니다.";
            if (dt == null)
            {
                MessageBox.Show(str, "레포트 생성",MessageBoxButtons.OK,MessageBoxIcon.Information);
                SetBottomStatusLabel(str);
                return;
            }
            else
            {
                if (MessageBox.Show("레포트를 생성하시겠습니까?","레포트 생성", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        ShipmentClosingVO vo = new ShipmentClosingVO();
                        vo.start_date = dtpFromDate.Value.ToShortDateString();
                        vo.end_date = dtpToDate.Value.ToShortDateString();

                        if (cboCustomer.Text != "선택")
                        {
                            vo.company_code = cboCustomer.SelectedValue.ToString();
                        }

                        if (txtProduct.Text != "")
                        {
                            vo.product_name = txtProduct.Text.Trim();
                        }

                        shipment_service = new ShipmentService();
                        shipment_service.GetSalesCompleteStatus(vo);
                        SalesComplete ds = new SalesComplete();


                        Report_SalesComplete rpt = new Report_SalesComplete();


                        dt.TableName = "salescomplete";
                        ds.Tables.Add(dt);
                        rpt.DataSource = ds.Tables["salescomplete"];


                        using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                        {
                            printTool.ShowRibbonPreviewDialog();
                        }

                        //WinReport_SC frm = new WinReport_SC(rpt);
                        //frm.documentViewer1.DocumentSource = rpt;

                        ////??
                        //frm.documentViewer1.PrintingSystem.ExecCommand(
                        //    DevExpress.XtraPrinting.PrintingSystemCommand.SubmitParameters
                        //    , new object[] { true });

                        //frm.ShowDialog();
                    }
                    catch (Exception err)
                    {
                        string str2 = "레포트를 생성할 수 없습니다.";
                        SetBottomStatusLabel(str2);
                        if (MessageBox.Show(str2, "레포트 생성 실패", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                            return;
                        }

                    }
                }
                
            }
           
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
