using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Team3VO;

namespace Team3
{
    public partial class FacilitieInfoPop : DialogForm
    {
        DateTime today = DateTime.Now;
        ResourceService R_service;
        CommonCodeService service;
        List<CommonVO> list;
        EditMode mode;
        public enum EditMode { Input, Update };
        MachineVO VO;

        //추가
        public FacilitieInfoPop(EditMode editMode, string code, string i)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                mode = EditMode.Update;
                this.Text = "설비정보 수정";
            }
            if (editMode == EditMode.Input)
            {
                mode = EditMode.Input;
                this.Text = "설비정보 추가";
                txtMgrade_code.Text = code;
                lblGrCodeID.Text = i;


            }
        }
        //수정
        public FacilitieInfoPop(EditMode editMode, MachineVO VO)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                mode = EditMode.Update;
                this.Text = "설비정보 수정";
                this.VO = VO;

            }
            if (editMode == EditMode.Input)
            {
                mode = EditMode.Input;
                this.Text = "설비정보 추가";
            }
        }


        private void FacilitieInfoPop_Load(object sender, EventArgs e)
        {
            txtModifyTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", today);
            //콤보박스 바인딩
            {
                service = new CommonCodeService();
                list = service.GetCommonCodeAll();
                {
                    //사용유무
                    var mCode = (from item in list
                                 where item.common_type == "user_flag"
                                 select item).ToList();

                    ComboUtil.ComboBinding<CommonVO>(cboIsUsed, mCode, "common_value", "common_name");
                }
                {
                    var mCode = (from item in list
                                 where item.common_type == "user_flag"
                                 select item).ToList();

                    mCode.Reverse();
                    ComboUtil.ComboBinding<CommonVO>(cboIsOS, mCode, "common_value", "common_name");
                }
                R_service = new ResourceService();
                var Fatory_list = R_service.GetFactoryAll();

                var WH1 = (from wh1 in Fatory_list
                           where wh1.facility_class == "창고"
                           select wh1).ToList();
                ComboUtil.ComboBinding<FactoryDB_VO>(cboUseWH, WH1, "factory_id", "factory_name", "미선택");
                var WH2 = (from wh1 in Fatory_list
                           where wh1.facility_class == "창고"
                           select wh1).ToList();
                ComboUtil.ComboBinding<FactoryDB_VO>(cboOkWH, WH2, "factory_id", "factory_name", "미선택");
                var WH3 = (from wh1 in Fatory_list
                           where wh1.facility_class == "창고"
                           select wh1).ToList();
                ComboUtil.ComboBinding<FactoryDB_VO>(cboNgWH, WH3, "factory_id", "factory_name", "미선택");
            }
            if (mode == EditMode.Update)
            {
                MachineVO vo = this.VO;
                lblID.Text = VO.m_id.ToString();
                lblGrCodeID.Text = VO.mgrade_id.ToString();
                txtMgrade_code.Text = VO.mgrade_code;
                txtCodeFacility.Text = VO.m_code;
                txtNameFacility.Text = VO.m_name;
                cboUseWH.Text = VO.m_use_sector;
                cboOkWH.Text = VO.m_ok_sector;
                cboNgWH.Text = VO.m_ng_sector;
                cboIsUsed.Text = VO.m_yn;
                cboIsOS.Text = VO.m_os_yn;
                txtModifier.Text = VO.m_uadmin;
                txtModifyTime.Text = VO.m_udate;
                txtCheck.Text = VO.m_check;
                txtComment.Text = VO.m_comment;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                if (txtCodeFacility.Text == "")
                {
                    MessageBox.Show("설비코드을 입력해주세요");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (txtNameFacility.Text == "")
                {
                    MessageBox.Show("설비명을 입력해주세요");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (cboUseWH.SelectedIndex == 0)
                {
                    MessageBox.Show("소진창고를 선택해주세요");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (cboOkWH.SelectedIndex == 0)
                {
                    MessageBox.Show("양품창고를 선택해주세요");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (cboNgWH.SelectedIndex == 0)
                    cboNgWH.Text = "";
                #endregion
                MachineVO VO = new MachineVO();
                VO.mgrade_id = Convert.ToInt32(lblGrCodeID.Text);
                VO.mgrade_code = txtMgrade_code.Text;
                VO.m_code = txtCodeFacility.Text;
                VO.m_name = txtNameFacility.Text;
                VO.m_use_sector = cboUseWH.Text;
                VO.m_ok_sector = cboOkWH.Text;
                VO.m_ng_sector = cboNgWH.Text;
                VO.m_yn = cboIsUsed.Text;
                VO.m_os_yn = cboIsOS.Text;
                VO.m_uadmin = txtModifier.Text;
                VO.m_udate = txtModifyTime.Text;
                VO.m_check = txtCheck.Text;
                VO.m_comment = txtComment.Text;
                //등록
                if (mode == EditMode.Input)
                {
                    bool bResult = R_service.InsertMachine(VO);
                    if (bResult)
                    {
                        MessageBox.Show("등록성공");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("등록실패");
                        this.DialogResult = DialogResult.None;
                    }
                }
                else if (mode == EditMode.Update)
                {
                    VO.m_id = Convert.ToInt32(lblID.Text);
                    bool bResult = R_service.UpdateMachine(VO);
                    if (bResult)
                    {
                        MessageBox.Show("수정성공");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("수정실패");
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch(Exception err)
            {
                string str = err.Message;
            }
        }
    }
}
