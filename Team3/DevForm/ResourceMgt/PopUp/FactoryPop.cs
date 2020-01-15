﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team3VO;
using System.Linq;


namespace Team3
{
    public partial class FactoryPop : DialogForm
    {
        public enum EditMode { Input, Update };
        CommonCodeService service;
        List<CommonVO> list;
        public FactoryPop(EditMode editMode ,int i=0)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                this.Text = "공장정보 수정";
            }
            if (editMode == EditMode.Input)
            {
                this.Text = "공장정보 추가";
            }
        }
       

        private void FactoryPop_Load(object sender, EventArgs e)
        {
            service = new CommonCodeService();

            list = service.GetCommonCodeAll();
            {
                //시설군
                var mCode = (from item in list
                             where item.COMMON_TYPE == "facility_class_id"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cbofacilitiesGroup, mCode, "COMMON_VALUE", "COMMON_NAME", "미선택");
            }
            {
                var mCode = (from item in list
                             where item.COMMON_TYPE == "facility_type"
                             select item).ToList();

                ComboUtil.ComboBinding<CommonVO>(cboDivFacility, mCode, "COMMON_VALUE", "COMMON_NAME", "미선택");
            }
        }
    }
}
