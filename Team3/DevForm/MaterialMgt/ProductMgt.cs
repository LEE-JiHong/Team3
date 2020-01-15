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
    public partial class ProductMgt : VerticalGridBaseForm
    {
        CommonCodeService common_service = new CommonCodeService();
        List<CommonVO> codelist;
        public ProductMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductPop frm = new ProductPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            LoadDGV();
            ComboBinding();
        }
        private void LoadDGV()
        {
            ProductService service = new ProductService();
            List<ProductVO> list = service.GetAllProducts();
            ProductVO vo = new ProductVO();

            //GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "ID", , true, 100);


            dgvProductList.DataSource = list;
        }
        private void ComboBinding()
        {
            common_service = new CommonCodeService();
            codelist = common_service.GetCommonCodeAll();
            List<CommonVO> _cboUseFlag = (from item in codelist
                                          where item.COMMON_TYPE == "user_flag"
                                          select item).ToList();
            ComboUtil.ComboBinding(cboIsUsed, _cboUseFlag, "COMMON_VALUE", "COMMON_NAME", "선택");

            _cboUseFlag = (from item in codelist
                           where item.COMMON_TYPE == "item_type"
                           select item).ToList();
            ComboUtil.ComboBinding(cboProductType, _cboUseFlag, "COMMON_VALUE", "COMMON_NAME", "선택");


        }
    }
}
