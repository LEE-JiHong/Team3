using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class SalesMasterUpload : DgvBaseForm
    {
        string versionName;

        public SalesMasterUpload()
        {
            InitializeComponent();
        }

        private void SalesMasterUpload_Load(object sender, EventArgs e)
        {
            //데이터 가져오기(영업마스터 데이터)

            //데이터가 없을 경우
            

            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "planDate", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "순번", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "WORK_ORDER_ID", "", true, 130);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "업체코드", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납품처", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고P/NO", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "계획수량합계", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "납기일", "", true);
        }

        //엑셀 등록 버튼
        private void btnAddExcel_Click(object sender, EventArgs e)
        {
            SalesMasterDialog frm = new SalesMasterDialog();

            if (versionName != "")
            {
                MessageBox.Show("test");
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Columns.Clear();

                dataGridView1.DataSource = frm.Data;
            }
        }

        //양식 다운로드 버튼
        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("파일 업로드는 필수입니다.");
            }
            else
            { 
                
            }
        }
    }
}
