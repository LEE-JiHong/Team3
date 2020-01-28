using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team3VO;

namespace Team3
{
    public partial class BomMgt : Team3.HorizonGridBaseForm
    {
        CommonCodeService common_service;
        List<CommonVO> codelist;
        
        public BomMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BomPop frm = new BomPop();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = "신규 BOM이 등록되었습니다.";
            }
        }

        private void BomMgt_Load(object sender, EventArgs e)
        {
            LoadDGV();
            ComboBinding();
        }
        private void LoadDGV()
        {
            InitControl();
            BomService service = new BomService();
            List<BomVO> list = service.GetBomAll();

            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품목유형", "product_type", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품목", "product_codename", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품명", "product_name", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "단위", "product_unit", true, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "단위수량", "product_unit_count", true, 80, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "발주방식", "product_ordertype", true, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "최소발주수량", "product_lorder_count", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "안전재고수량", "product_safety_count", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "사용여부", "product_yn", true, 78, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "담당자", "product_admin", true, 100);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "입고창고", "product_in_sector", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "출고창고", "product_out", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "납품업체", "product_supply_com", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "발주업체", "product_demand_com", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "측정방식", "product_meastype", true, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "LeadTime", "product_leadtime", true, 80, DataGridViewContentAlignment.MiddleRight);
            #region visible_false
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "최솟값", "product_lsl", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "최댓값", "product_usl", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "아이템코드", "product_itemcode", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품번", "product_id", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품명코드", "product_code", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "수정자", "product_uadmin", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "수정일", "product_udate", false, 130);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "비고", "product_comment", false, 130);

            #endregion

            dgvBom.DataSource = list;
            
        }

        private void InitControl()
        {
            //cboDeployment
            string[] arr_deployment = new string[] {"선택", "정전개", "역전개" };
            cboDeployment.Items.AddRange(arr_deployment);
            cboDeployment.SelectedIndex = 0;
        }
        private void ComboBinding()
        {
            common_service = new CommonCodeService();
            codelist = common_service.GetCommonCodeAll();
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.common_type == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "common_value", "common_name", "선택");
        }
    }
}
