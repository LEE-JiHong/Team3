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
    public partial class ProductMgt : VerticalGridBaseForm
    {
        public ProductMgt()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductPop frm = new ProductPop();
            if(frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        private void LoadDGV()
        {
            ProductService service = new ProductService();
            List<ProductVO> list = service.GetAllProducts();
            ProductVO vo = new ProductVO();

            //GridViewUtil.AddNewColumnToDataGridView(dgvProductList, "ID", , true, 100);


            dgvProductList.DataSource = list;
        }
    }
}
