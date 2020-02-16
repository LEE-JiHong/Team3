using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3
{
    public partial class LoadingForm : Form
    {
        public Action Function { get; set; }

        private Image loadingImage;

        public LoadingForm()

        {

            InitializeComponent();


            this.loadingImage = Image.FromFile(@"C:\Users\alsch\source\repos\LEE-JiHong\Team3\Team3\Resources\loading.gif");

            this.Shown += new EventHandler(Form_Loaded);


        }

        private void Form_Loaded(object sender, EventArgs e)

        {

            var thread = new Thread(

                () =>

                {

                    Function?.Invoke();

                    this.Invoke(

                        (Action)(() =>

                        {

                            this.Close();

                        }));

                });

            thread.Start();

        }

    }
}
