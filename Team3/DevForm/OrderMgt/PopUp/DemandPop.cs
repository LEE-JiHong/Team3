using log4net.Core;
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
    public partial class DemandPop : Team3.DialogForm
    {
        List<SOMasterVO> somasterList;

        public DemandPop()
        {
            InitializeComponent();
        }
        private void DemandPop_Load(object sender, EventArgs e)
        {
           
            OrderService service = new OrderService();

            try
            {
                List<string> list = service.GetPlanID();

                cbOrderGubun.DataSource = list;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }

            SetDataGrid();
        }

        private void SetDataGrid()
        {
            dataGridView1.Columns.Clear();

            GridViewUtil.SetDataGridView(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;

            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "고객WO", "so_wo_id", true, 150);
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
            //GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "발주구분", "", true);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "so_id", "so_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "plan_id", "plan_id", false);
            GridViewUtil.AddNewColumnToDataGridView(dataGridView1, "company_type", "company_type", false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string startDate = DateTime.Now.ToShortDateString();

            OrderService service = new OrderService();

            try
            {
                somasterList = service.GetSOMaster(cbOrderGubun.Text);
                dataGridView1.DataSource = somasterList;
            }
            catch (Exception err)
            {
                LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("조회 버튼을 먼저 눌러주십시오.", "조회", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            OrderService service = new OrderService();

            if (MessageBox.Show("수요계획을 생성하시겠습니까?", "수요계획생성", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int resultRow = service.SearchPlanIDInDemand(cbOrderGubun.Text);
                    if (resultRow > 0)
                    {
                        MessageBox.Show("이미 생성된 수요계획이 있습니다.", "수요계획",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        List<DemandPlanVO> list = new List<DemandPlanVO>();

                        for (int i = 0; i < somasterList.Count; i++)
                        {
                            DemandPlanVO vo = new DemandPlanVO();
                            vo.plan_id = cbOrderGubun.Text;
                            vo.d_count = somasterList[i].so_pcount;
                            vo.d_date = somasterList[i].so_edate;
                            vo.so_id = somasterList[i].so_id;
                            list.Add(vo);
                        }

                        bool result = service.AddDemandPlan(list);

                        if (result)
                        {
                            MessageBox.Show("성공적으로 수요계획을 생성하였습니다.", "수요계획생성", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("수요계획 생성에 실패하였습니다.", "수요계획생성실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception err)
                {
                    LoggingUtility.GetLoggingUtility(err.Message, Level.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
