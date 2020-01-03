using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Team3
{
    public partial class SalesMasterDialog : DialogForm
    {
        public SalesMasterDialog()
        {
            InitializeComponent();
        }

        public string FilePath
        {
            get { return txtFilePath.Text; }
            set { txtFilePath.Text = value; }
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "엑셀 파일 (*.xls)|*.xls|엑셀 파일 (*.xlsx)|*.xlsx|모든 파일 (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //filePath = openFileDialog.FileName;

                    txtFilePath.Text = openFileDialog.FileName;

                    FilePath = txtFilePath.Text;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
