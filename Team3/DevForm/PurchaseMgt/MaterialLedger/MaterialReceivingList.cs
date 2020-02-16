using log4net.Core;
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
    public partial class MaterialReceivingList : Team3.VerticalGridBaseForm
    {
        public MaterialReceivingList()
        {
            InitializeComponent();
        }

        private void MaterialReceivingList_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();


            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "선택";
            chk.Name = "chk";
            chk.Width = 40;
            dataGridView1.Columns.Add(chk);

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주시리얼", "order_serial", true, 110);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고일", "order_pdate", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고창고", "factory_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품목", "product_codename", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "입고량", "order_qcount", true, 150);
            GridViewUtil.AddNewColumnToTextBoxGridView(dataGridView1, "취소량", "", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "잔량", "order_qcount", true, 150);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "업체", "company_name", true, 150);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //조회 버튼
            MaterialLedgerService service = new MaterialLedgerService();
            DataTable dt = service.GetMaterialInList();
            SetDataGrid();
            dataGridView1.DataSource = dt;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //입고취소 버튼
            List<MaterialReceivingVO> list = new List<MaterialReceivingVO>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                if (isCellChecked)
                {
                    MaterialReceivingVO vo = new MaterialReceivingVO();
                    vo.order_serial = row.Cells[1].Value.ToString();
                    vo.product_codename = row.Cells[4].Value.ToString();
                    vo.order_count = Convert.ToInt32(row.Cells[7].Value);
                    vo.product_name = row.Cells[5].Value.ToString();

                    list.Add(vo);
                }
            }

            //발주취소 버튼 (발주번호, PlanID 값)
            MaterialLedgerService service = new MaterialLedgerService();

            try
            {
                bool result = service.CancelMaterial(list);

                if (result)
                {
                    MessageBox.Show("성공적으로 입고취소가 완료되었습니다.");
                    SetBottomStatusLabel("성공적으로 입고취소가 완료되었습니다.");
                    btnSearch.PerformClick();
                }
                else
                {
                    MessageBox.Show("입고취소 실패하였습니다. 다시 시도하여 주십시오.");
                    SetBottomStatusLabel("입고취소 실패하였습니다. 다시 시도하여 주십시오.");
                }
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }
    }
}
