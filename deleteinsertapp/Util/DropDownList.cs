using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deleteinsertapp.Util
{
    public class DropDownList
    {
        public static List<SelectListItem> getSelectListItem()
        {
            List<SelectListItem> selectoptions = new List<SelectListItem>();

            selectoptions.Add(new SelectListItem() { Value = "1", Text = "1" });
            selectoptions.Add(new SelectListItem() { Value = "2", Text = "2" });
            selectoptions.Add(new SelectListItem() { Value = "3", Text = "3" });
            selectoptions.Add(new SelectListItem() { Value = "4", Text = "4" });
            selectoptions.Add(new SelectListItem() { Value = "5", Text = "5" });
            selectoptions.Add(new SelectListItem() { Value = "6", Text = "6" });
            selectoptions.Add(new SelectListItem() { Value = "7", Text = "7" });
            selectoptions.Add(new SelectListItem() { Value = "8", Text = "8" });
            selectoptions.Add(new SelectListItem() { Value = "9", Text = "9" });
            selectoptions.Add(new SelectListItem() { Value = "10", Text = "10" });
            selectoptions.Add(new SelectListItem() { Value = "11", Text = "11" });
            selectoptions.Add(new SelectListItem() { Value = "12", Text = "12" });

            return selectoptions;
        }
    }
}