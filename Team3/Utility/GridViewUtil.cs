using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Team3
{
    public class GridViewUtil
    {

        /// <summary>
        /// 데이터그리드뷰 텍스트 추가
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="headerText"></param>
        /// <param name="dataPropertyName"></param>
        /// <param name="visibility"></param>
        /// <param name="width"></param>
        /// <param name="textAlign"></param>
        /// <param name="numCheck">숫자 천 단위 설정</param>
        public static void AddNewColumnToDataGridView(DataGridView dgv, string headerText, string dataPropertyName,
        bool visibility, int width = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft, bool numCheck = false)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = headerText;
            col.DataPropertyName = dataPropertyName;
            col.Width = width;
            col.Visible = visibility;
            col.ValueType = typeof(string);
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = textAlign;

            if (numCheck)
            {
                col.DefaultCellStyle.Format = "#,##0";
            }

            dgv.Columns.Add(col);
        }

        /// <summary>
        /// 데이터그리드뷰 버튼
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="Text"></param>
        /// <param name="visibility"></param>
        /// <param name="width"></param>
        /// <param name="textAlign"></param>
        public static void AddNewColumnToButtonGridView(DataGridView dgv, string Text,string HeaderText, string PropertyName,
bool visibility, int width = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = HeaderText;
            btn.Text = Text;
            btn.Width = width;
            btn.Visible = visibility;
            btn.FlatStyle = FlatStyle.Standard;
            btn.DataPropertyName = PropertyName;
            btn.DefaultCellStyle.Alignment = textAlign;
            btn.UseColumnTextForButtonValue = true;
            btn.Name = "btnInsert";
            //btn.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            dgv.Columns.Add(btn);
        }

        /// <summary>
        /// 데이터그리드뷰 텍스트박스
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="visibility"></param>
        /// <param name="width"></param>
        /// <param name="textAlign"></param>
        public static void AddNewColumnToTextBoxGridView(DataGridView dgv, string HeaderText, string PropertyName,
                                        bool visibility, int width = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn txtbox = new DataGridViewTextBoxColumn();
            txtbox.HeaderText = HeaderText;
            txtbox.Width = width;
            txtbox.Visible = visibility;
            txtbox.DataPropertyName = PropertyName;
            txtbox.DefaultCellStyle.Alignment = textAlign;
            txtbox.DefaultCellStyle.BackColor = Color.White;
            dgv.Columns.Add(txtbox);
        }

        /// <summary>
        /// 데이터그리드뷰 콤보박스
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dgv"></param>
        /// <param name="HeaderText"></param>
        /// <param name="list"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="visibility"></param>
        /// <param name="width"></param>
        /// <param name="textAlign"></param>
        public static void AddNewColumnToComboGridView<T>(DataGridView dgv, string HeaderText, List<T> list, string displayMember, string valueMember,
bool visibility, int width = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = HeaderText;
            cmb.Width = width;
            cmb.Visible = visibility;
            cmb.DefaultCellStyle.Alignment = textAlign;
            cmb.DefaultCellStyle.Padding = new Padding(0, 5, 0, 5);
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            ComboUtil.GridComboBinding(cmb, list, displayMember, valueMember);
            dgv.Columns.Add(cmb);

        }

        /// <summary>
        /// 데이터그리드뷰 색셋팅
        /// </summary>
        /// <param name="grid"></param>
        public static void SetDataGridView(DataGridView grid)
        {
            
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;

            grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //grid.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            //grid.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            //grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToResizeColumns = false;
        }
       

    }
}
