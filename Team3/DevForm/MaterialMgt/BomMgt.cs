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
              //  toolStripStatusLabel1.Text = "abc";
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
