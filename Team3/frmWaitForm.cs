using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3
{
    public partial class frmWaitForm : Form
    {
        public Action Worker { get; set; }
        public frmWaitForm(Action worker)
        {
            InitializeComponent();
            Worker = worker;
        }

        private void frmWaitForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); },//쓰레드 풀에서 쓰레드 하나를 생성해서 스타트까지 
                TaskScheduler.FromCurrentSynchronizationContext());    // ContinueWith Task 작업 완료 된 후에 실행할 작업(람다식으로 작성해야함)
           // UI쓰레드쪽에서
           //showinTaskBar false 하면 작업표시줄에 표시 안됨
        }
    }
}
