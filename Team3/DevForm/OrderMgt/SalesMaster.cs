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
        List<CompanyVO> CompanyList;
        List<CompanyVO> DestinationList;

        public SalesMaster()
        {
            InitializeComponent();
        }

        private void SalesMaster_Load(object sender, EventArgs e)
        {
            //납기일 초기화
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(+1).AddDays(-1);

            //등록일 초기화
            dtpRegFirstDate.Value = DateTime.Now.AddMonths(-1);
            dtpRegLastDate.Value = DateTime.Now;

            OrderService service = new OrderService();
            //List<SOMasterVO> list = service.GetSOMasterAll();

            //고객사, 도착지 콤보박스 바인딩
            CompanyList = new List<CompanyVO>();
            CompanyList = service.GetCompanyAll("cooperative");
            ComboUtil.ComboBinding(cboCompany, CompanyList, "company_code", "company_name", "선택");

            DestinationList = new List<CompanyVO>();
            DestinationList = service.GetCompanyAll("cooperative");
            ComboUtil.ComboBinding(cboDestination, DestinationList, "company_code", "company_name", "선택");


            //datagridview
            SetDataGrid();
            //dataGridView1.DataSource = list;

        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "so_id", "so_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "plan_id", "plan_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "company_type", "company_type", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객WO", "so_wo_id", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객사코드", "company_code", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객사명", "company_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "도착지코드", "company_code", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "도착지명", "company_name", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객주문유형", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "등록일", "so_sdate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "생산납기일", "so_edate", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "주문수량", "so_pcount", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "출고수량", "so_ocount", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "취소수량", "so_ccount", true);
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주구분", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "비고", "so_comment", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수정자", "so_uadmin", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "수정일", "so_udate", true);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //등록버튼
            SODialog frm = new SODialog(SODialog.EditMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //OrderService service = new OrderService();
                //List<SOMasterVO> list = service.GetSOMasterAll();

                ////datagridview
                //SetDataGrid();
                //dataGridView1.DataSource = list;
            }
        }

        private void btnDemandPlan_Click(object sender, EventArgs e)
        {
            ////수요계획생성 버튼
            DemandPop frm = new DemandPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SOMasterVO vo = new SOMasterVO();

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                vo = row.DataBoundItem as SOMasterVO;
                //if (vo != null)
                //{
                //    MessageBox.Show("데이터를 선택하여주십시오.");
                //}
            }
            //for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            //{
            //    vo = (SOMasterVO)dataGridView1.SelectedRows[i].DataBoundItem;
            //}

            //수정버튼
            SODialog frm = new SODialog(SODialog.EditMode.Update,vo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회 버튼
            WhereSoVO vo = new WhereSoVO();
            vo.startDate = dtpStartDate.Value.ToShortDateString();
            vo.endDate = dtpEndDate.Value.ToShortDateString();

            vo.RegStartDate = dtpRegFirstDate.Value.ToShortDateString();
            vo.RegEndDate = dtpRegLastDate.Value.ToShortDateString();

            if (cboCompany.Text != "선택")
            {
                vo.CompanyName = cboCompany.Text;
            }

            OrderService service = new OrderService();
            List<SOMasterVO> list = service.GetSOMasterAll(vo);
            dataGridView1.DataSource = list;
        }
    }
}
