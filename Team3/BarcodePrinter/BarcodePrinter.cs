using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3
{
    public partial class BarcodePrinter : Form
    {
        CheckBox headerCheckBox = new CheckBox();
        public BarcodePrinter()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
       

            AddNewColumnToDataGridView(dataGridView1, "품명", "product_name", true, 200);
            AddNewColumnToDataGridView(dataGridView1, "파트코드", "product_code", true, 90);
            //AddNewColumnToDataGridView(dataGridView1, "아이템코드", "product_itemcode", true, 70);
            AddNewColumnToDataGridView(dataGridView1, "고객명", "company_name", true, 85);
            //AddNewColumnToDataGridView(dataGridView1, "수량", "Qty", true, 70);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            InitDataBinding(true);
        }

        private void InitDataBinding(bool bInit)
        {
            string strConn = ConfigurationManager.ConnectionStrings["DBconnectionMain"].ConnectionString;
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                //string sql = @"select product_name, product_code,product_itemcode from TBL_PRODUCT where product_type = 'FP' ";
                string sql = @"select product_name, product_code,product_itemcode,cp.company_name from TBL_PRODUCT p inner join TBL_COMPANY cp on p.product_supply_com = cp.company_code where product_type = 'FP' ";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "BarcodeList");
                dataGridView1.DataSource = ds.Tables["BarcodeList"];

                //if (bInit)
                //{
                //    sql = "select ProductID, ProductName from Products Order By ProductName";
                //    da = new SqlDataAdapter(sql, conn);
                //    da.Fill(ds, "ProductList");

                //    //comboBox1.DisplayMember = "ProductName";
                //    //comboBox1.ValueMember = "ProductID";
                //    //comboBox1.DataSource = ds.Tables["ProductList"];
                //}
                conn.Close();
            }
        }

        private void AddNewColumnToDataGridView(DataGridView dgv, string headerText, string dataPropertyName, bool visibility, int colWidth = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn gridCol = new DataGridViewTextBoxColumn();
            gridCol.HeaderText = headerText;
            gridCol.DataPropertyName = dataPropertyName;
            gridCol.Width = colWidth;
            gridCol.Visible = visibility;
            gridCol.ValueType = typeof(string);
            gridCol.ReadOnly = true;
            gridCol.DefaultCellStyle.Alignment = textAlign;
            dgv.Columns.Add(gridCol);
        }

        private void HeaderCheckBox_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                chkBox.Value = headerCheckBox.Checked;
            }
        }




        private void Button2_Click(object sender, EventArgs e)
        {
            List<BarcodeFormat> barcodeData = new List<BarcodeFormat>();
            string result = string.Empty;
            for(int i= int.Parse(txtSerialStartNo.Text);i<= int.Parse(txtSerialEndNo.Text);i++)
            {
                barcodeData.Add(new BarcodeFormat() { BarcodeData= resultFomat = productCode + dateTime + String.Format("{0:0000}", i) });
                result += barcodeData[i- int.Parse(txtSerialStartNo.Text)];
            }

            

            DataTable dt = new DataTable();
            dt = ListToDataTable.ToDataTable(barcodeData);


            XtraReport3 rpt = new XtraReport3();
            rpt.DataSource = dt;
            ReportPreviewForm frm = new ReportPreviewForm(rpt);

            //Form2 frm = new Form2();
            //frm.documentViewer1.DocumentSource = rpt;
            //frm.ShowDialog();


            //List<int> chkBarcodeIDList = new List<int>();
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    bool isCellChecked = Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);

            //    if (isCellChecked)
            //    {
            //        chkBarcodeIDList.Add(Convert.ToInt32(row.Cells[1].Value));
            //    }
            //}

            //string chkBarCodeID = string.Join(", ", chkBarcodeIDList); //1, 20, 12 ...

            //string strConn = ConfigurationManager.ConnectionStrings["MyDBConn"].ConnectionString;
            //DataSet ds = new DataSet();
            //using (SqlConnection conn = new SqlConnection(strConn))
            //{
            //    conn.Open();
            //    string sql = @"select Right('00000'+cast(BarcodeID as varchar(5)) ,'5') as BarcodeID,ProductName, QuantityPerUnit, Qty
            //                from BarCodeOutput b, Products p where b.ProductID = p.ProductID and BarcodeID in (" + chkBarCodeID + ") order by BarCodeID desc";
            //    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //    da.Fill(ds, "BarcodeList");
            //    conn.Close();
            //}
            //XtraReport3 rpt = new XtraReport3();
            //rpt.DataSource = ds.Tables["BarcodeList"];
            ////ReportPreviewForm frm = new ReportPreviewForm(rpt);

            //Form2 frm = new Form2();
            //frm.documentViewer1.DocumentSource = rpt;
            //frm.ShowDialog();
        }

        string productCode= string.Empty;
        string dateTime =string.Empty;
        string serialSdata= string.Empty;
        string resultFomat = string.Empty;
        private void MaskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtSerialEndNo.Text = (int.Parse(txtSerialStartNo.Text) + int.Parse(txtCalNo.Text)-1).ToString();
                productCode = txtProductCode.Text + "%c";
                dateTime = dateTimePicker1.Value.ToString("yyMMdd") + "%d";
                serialSdata = String.Format("{0:0000}", int.Parse(txtSerialStartNo.Text));


                resultFomat = productCode + dateTime;


                txtResult.Text = txtProductCode.Text + dateTimePicker1.Value.ToString("yyMMdd")+serialSdata;
            }
        }

        private void MaskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtProductCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCompany.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }


    public static class ListToDataTable
    {
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }


    public class BarcodeFormat
    {
      public string BarcodeData { get; set; }
    }
}
