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
    public partial class BORPop : Team3.DialogForm
    {

        CommonCodeService common_service;
        List<CommonVO> common_list;
        BORDB_VO vo;
        ResourceService R_survice;

        public enum EditMode { Input, Update };
        EditMode mode;
        public BORPop(EditMode editMode)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                this.Text = "BOR정보 수정";
                mode = EditMode.Update;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "BOR정보 추가";
                mode = EditMode.Input;
            }
        }
        public BORPop(EditMode editMode, string i, string route)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                mode = EditMode.Update;
                this.Text = "BOR정보 수정";
                lblID.Text = i;
                lblRoute.Text = route;

            }
            if (editMode == EditMode.Input)
            {
                this.Text = "BOR정보 추가";
                mode = EditMode.Input;
            }
        }


        private void BORPop_Load(object sender, EventArgs e)
        {

            R_survice = new ResourceService();
            #region 콤보박스 바인딩
            common_service = new CommonCodeService();
            common_list = common_service.GetCommonCodeAll();
            {
                //공정
                var mCode = (from item in common_list
                             where item.common_type == "route"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboRoute, mCode, "common_value", "common_name", "미선택");
            }
            {

                //사용유무
                var mCode = (from item in common_list
                             where item.common_type == "user_flag"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboYN, mCode, "common_value", "common_name");
            }
            R_survice = new ResourceService();
            List<MachineVO> lst = R_survice.GetMachineAll();
            ComboUtil.ComboBinding<MachineVO>(cboM_name, lst, "m_id", "m_name", "미선택");
            ProductService product_service = new ProductService();
            List<ProductVO> list = product_service.GetAllProducts();
            ComboUtil.ComboBinding<ProductVO>(cboP_Name, list, "product_id", "product_name", "미선택");
            #endregion

            if (mode == EditMode.Update)
            {

                R_survice = new ResourceService();
                vo = R_survice.GetBORByID(Convert.ToInt32(lblID.Text), lblRoute.Text);
                lblID.Text = vo.bor_id.ToString();
                cboP_Name.Text = vo.product_name;
                cboM_name.Text = vo.m_name;
                cboYN.Text = vo.bor_yn;
                cboRoute.Text = vo.common_name;
                txtComment.Text = vo.bor_comment;
                txtReadyTime.Text = vo.bor_readytime.ToString();
                txtTactTime.Text = vo.bor_tacktime.ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int su = Convert.ToInt32(txtReadyTime.Text);
            if (su > 36)
            {
                txtReadyTime.Text = "";
                MessageBox.Show("36시간 보다 클 수 없습니다");
                return;
            }
            try
            {
                BorVO vo = new BorVO();
                if (cboP_Name.SelectedIndex == 0 || cboM_name.SelectedIndex == 0 ||
                    cboRoute.SelectedIndex == 0)
                {
                    MessageBox.Show("선택하지 않은 값이 있습니다");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else
                {


                    vo.bor_comment = txtComment.Text;
                    vo.bor_readytime = Convert.ToInt32(txtReadyTime.Text);
                    vo.bor_tacktime = Convert.ToInt32(txtTactTime.Text);
                    vo.m_id = Convert.ToInt32(cboM_name.SelectedValue);
                    vo.bom_id = Convert.ToInt32(cboP_Name.SelectedValue);
                    vo.bor_route = cboRoute.SelectedValue.ToString();
                    vo.bor_yn = cboYN.SelectedValue.ToString();
                    bool bResult = false;
                    if (mode == EditMode.Input)
                    {
                        bResult = R_survice.InsertBOR(vo);
                        if (bResult)
                        {
                            //      MessageBox.Show("등록성공");
                            this.DialogResult = DialogResult.OK;
                            return;
                        }
                        else if (!bResult)
                        {
                            //  MessageBox.Show("등록실패");
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    else if (mode == EditMode.Update)
                    {
                        vo.bor_id = Convert.ToInt32(lblID.Text);
                        bResult = R_survice.UpdateBOR(vo);
                        if (bResult)
                        {
                            //  MessageBox.Show("수정성공");
                            this.DialogResult = DialogResult.OK;

                            return;
                        }
                        else if (!bResult)
                        {
                            // MessageBox.Show("수정실패");
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }

                }

            }
            catch (NullReferenceException err)
            {
                MessageBox.Show("입력되지 않은값이 있습니다, 다시 확인해주세요", "입력확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            catch (Exception err)
            {
                string str = err.Message;
            }
        }

        private void txtTactTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}