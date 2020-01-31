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
    //Material of unit's price management 자재 단가 관리
    public partial class MUPMMgt : Team3.VerticalGridBaseForm
    {
        PriceService price_service;
        public MUPMMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MUPMPop frm = new MUPMPop(MUPMPop.EditMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                price_service = new PriceService();
                List<PriceInfoVO> new_priceinfo_list = price_service.GetPriceInfo("COOPERATIVE");    //등록후 다시 조회
                dgvMUPM.DataSource = new_priceinfo_list;
                SetBottomStatusLabel("신규 자재단가가 등록되었습니다.");
            }
        }

        private void MUPMMgt_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        private void InitControl()
        {
            OrderService order_service = new OrderService();
            #region 발주업체cbo
            List<CompanyVO> company_list = order_service.GetCompanyAll("CUSTOMER");
            ComboUtil.ComboBinding(cboCompany, company_list, "company_id", "company_name", "선택");
            #endregion





            price_service = new PriceService();
            List<PriceInfoVO> pricelist = price_service.GetPriceInfo("COOPERATIVE");

            dgvMUPM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMUPM.Columns.Add("Number", "No.");
            dgvMUPM.Columns[0].Width = 53;

            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "업체", "company_code", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "업체명", "company_name", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "품목", "product_codename", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "품명", "product_name", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "단위", "product_unit", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "현재단가", "price_present", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "이전단가", "price_past", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "시작일", "price_sdate", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "종료일", "price_edate", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "비고", "price_comment", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvMUPM, "사용유무", "price_yn", true, 100, DataGridViewContentAlignment.MiddleCenter);

            dgvMUPM.AutoGenerateColumns = false;
            dgvMUPM.DataSource = pricelist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PriceInfoVO vo = new PriceInfoVO();
            foreach (DataGridViewRow row in this.dgvMUPM.SelectedRows)
            {
                vo = row.DataBoundItem as PriceInfoVO;
            }

            MUPMPop frm = new MUPMPop(MUPMPop.EditMode.Update, vo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                price_service = new PriceService();
                List<PriceInfoVO> newPricelist = price_service.GetPriceInfo("COOPERATIVE");    //등록후 다시 조회
                dgvMUPM.DataSource = newPricelist;
                dgvMUPM.ClearSelection();
                SetBottomStatusLabel("자재단가 수정이 완료되었습니다.");
            }
        }
    }
}
