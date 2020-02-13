using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Team3.Service;
using Team3VO;
namespace Team3
{
    public partial class Business_showings : Team3.VerticalGridBaseForm
    {
        public Business_showings()
        {
            InitializeComponent();
        }

        private void Business_showings_Load(object sender, EventArgs e)
        {
            ProcessService P_service = new ProcessService();
            List<WorkRecode_VO> W_lst=P_service.WorkRecode();
            dataGridView1.DataSource = W_lst;
        }
    }
}
