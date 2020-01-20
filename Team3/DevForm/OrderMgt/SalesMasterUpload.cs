﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;

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
            versionName = DateTime.Now.ToShortDateString().Replace("-", "") + "_P";

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
                versionName = frm.PlanVersion;
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
                List<SOMasterVO> list = new List<SOMasterVO>();

                for (int i = 0; i<dataGridView1.Rows.Count; i++)
                {
                    SOMasterVO vo = new SOMasterVO();
                    vo.plan_id = versionName;
                    vo.so_wo_id = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    vo.so_pcount = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                    vo.company_code = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    vo.so_edate = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    vo.so_sdate = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    vo.product_name = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    list.Add(vo);
                }

                //DB
                OrderService service = new OrderService();
                bool result = service.AddSOMaster(list);

                if (result)
                {
                    Form fc = Application.OpenForms["Main"];
                    Main frm = (Main)fc;

                    frm.GetForm("영업마스터");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("영업마스터 생성에 실패하였습니다. 다시 시도하여주십시오.");
                    return;
                }
            }
        }
    }
}
