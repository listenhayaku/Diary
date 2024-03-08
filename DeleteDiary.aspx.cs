using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class DeleteDiary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null) Response.Redirect("~/Login");
            Debug.WriteLine("(debug)[DeleteDiary.Page_Load]start");
            Debug.WriteLine($"(debug)[DeleteDiary.Page_Load]Request:{Request["id"]}");

            //Global.dbmanager.DeleteDiary();
            Response.Redirect("~/DiaryList");
        }
    }
}