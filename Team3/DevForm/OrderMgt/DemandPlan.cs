﻿using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team3
{
    public partial class DemandPlan : VerticalGridBaseForm
    {
        public DemandPlan()
        {
            InitializeComponent();
        }

        private void DemandPlan_Load(object sender, EventArgs e)
        {
            //GridViewUtil.SetDataGridView(dataGridView1);
            OrderService service = new OrderService();

            try
            {
                List<string> list = service.GetPlanID();

                cboPlanID.DataSource = list;

                dtpEndDate.Value = DateTime.Now.AddMonths(1);

                //DataTable dt = service.GetDemandPlan(dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString(), cboPlanID.Text);

                //dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
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

                string filename = "test" + ".xlsx";

                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
                //byte[] temp = Properties.Resources.order;

                //System.IO.File.WriteAllBytes(tempPath, temp);

                Excel._Workbook workbook;

                workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);//tempPath

                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {
                            Excel.Range myRange = (Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnProductionPlan_Click(object sender, EventArgs e)
        {
            ProductionPop frm = new ProductionPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
            }
            //try
            //{
            //    if (MessageBox.Show($"\"{cboPlanID.Text}\"로 생산계획을 생성하시겠습니까?", "생산계획생성", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        OrderService service = new OrderService();
            //        bool result = service.AddProductionPlan(cboPlanID.Text);

            //        if (result)
            //        {
            //            Form fc = Application.OpenForms["Main"];
            //            Main frm = (Main)fc;

            //            frm.GetForm("생산계획");
            //            this.Close();
            //        }
            //        else
            //        {
            //            MessageBox.Show("생산계획 생성에 실패하였습니다. 다시 시도하여 주십시오.");
            //        }
            //    }
            //    else
            //    {
            //        return;   
            //    }
            //}
            //catch(Exception er)
            //{
            //    MessageBox.Show(er.Message);
            //} 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회 버튼
            try
            {
                dataGridView1.Columns.Clear();

                string startDate = dtpStartDate.Value.ToShortDateString();
                string endDate = dtpEndDate.Value.ToShortDateString();
                string planID = cboPlanID.Text;

                OrderService service = new OrderService();
                DataTable dt = service.GetDemandPlan(startDate, endDate, planID);

                dt.Columns[0].ColumnName = "번호";
                dt.Columns[1].ColumnName = "고객사코드";
                dt.Columns[2].ColumnName = "고객사설비";
                dt.Columns[3].ColumnName = "고객사명";
                dt.Columns[4].ColumnName = "고객주문번호";
                dt.Columns[5].ColumnName = "품목";

                dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gray; //Color.DimGray;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

                

                //foreach (DataColumn dc in dt.Columns)
                //{
                //    dc.ColumnName = "dd";
                //}

                

                dataGridView1.DataSource = dt;
                dataGridView1.Columns[4].Width = 150;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
    }
}
