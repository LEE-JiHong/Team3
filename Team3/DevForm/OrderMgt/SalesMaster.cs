using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;

namespace Team3
{
    public partial class SalesMaster : Team3.VerticalGridBaseForm
    {
        public SalesMaster()
        {
            InitializeComponent();
        }

        private void SalesMaster_Load(object sender, EventArgs e)
        {
            //납기일 초기화
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);

            OrderService service = new OrderService();
            List<SOMasterVO> list = service.GetSOMasterAll();

            //datagridview
            SetDataGrid();
            dataGridView1.DataSource = list;

        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객WO", "so_wo_id", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객사코드", "company_code", true, 130);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객사명", "company_name", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "도착지코드", "company_code", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "도착지명", "company_name", true);
            ////GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객주문유형", "", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "생산납기일", "so_edate", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "주문수량", "so_pcount", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "출고수량", "so_ocount", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "취소수량", "so_ccount", true);
            ////GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주구분", "", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "비고", "so_comment", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수정자", "so_uadmin", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수정일", "so_udate", true);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //등록버튼
            SODialog frm = new SODialog(SODialog.EditMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OrderService service = new OrderService();
                List<SOMasterVO> list = service.GetSOMasterAll();

                //datagridview
                SetDataGrid();
                dataGridView1.DataSource = list;
            }
        }

        private void btnDemandPlan_Click(object sender, EventArgs e)
        {
            ////수요계획생성 버튼
            DemandPop frm = new DemandPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }

            //try
            //{
            //    if (MessageBox.Show("수요계획을 생성하시겠습니까?", "생산계획생성", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            //catch (Exception er)
            //{
            //    MessageBox.Show(er.Message);
            //}
        }
    

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //수정버튼
            SODialog frm = new SODialog(SODialog.EditMode.Update);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
