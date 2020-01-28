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
    public partial class VerticalGridBaseForm : nomalBaseForm
    {
      //  private WinState windowstate = WinState.sub;
        public VerticalGridBaseForm()
        {
            InitializeComponent();
        }
        public VerticalGridBaseForm(WinState state) : base(state)
        {
            InitializeComponent();
        }

        private void VerticalGridBaseForm_Load(object sender, EventArgs e)
        {
            SetBottomStatusLabel(this.Tag.ToString());
        }
    }
}
