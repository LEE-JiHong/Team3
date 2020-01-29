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
            
            dgvBom.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBom.Columns.Add("Number", "No.");
            dgvBom.Columns[0].Width = 53;


            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품목", "bom_codename", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품명", "bom_name", true, 220);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "단위", "bom_unit", true, 78, DataGridViewContentAlignment.MiddleCenter);
            
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "사용여부", "bom_yn", true, 78, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "소요계획", "plan_yn", true, 78, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "시작일", "bom_sdate", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "종료일", "bom_edate", true, 130, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "수정자", "bom_uadmin", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "수정일", "bom_udate", true, 130, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "비고", "bom_comment", true, 130, DataGridViewContentAlignment.MiddleCenter);
            
            //GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품목유형", "product_type", true, 220);

            #region visible_false
            
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "품번", "product_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "BOM레벨", "bom_level", false, 80, DataGridViewContentAlignment.MiddleRight);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "소요량", "bom_use_count", false, 80, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "BomID", "bom_id", false, 100, DataGridViewContentAlignment.MiddleCenter);
            GridViewUtil.AddNewColumnToDataGridView(dgvBom, "상위품목", "bom_parent_id", false, 130);
            #endregion
            dgvBom.AutoGenerateColumns = false;
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

        private void dgvBom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvBom[11, dgvBom.CurrentRow.Index].Value.ToString()
            BomService service = new BomService();
            List<BomVO> bomDetail =  service.GetBomAll(dgvBom[11, dgvBom.CurrentRow.Index].Value.ToString());
            dgvBomDetail.DataSource = bomDetail;

        }
    }
}
