using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class NewDiary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null) Response.Redirect("~/Login");
        }

        protected void NewDiaryButton_Click(object sender,EventArgs e)
        {
            if (String.IsNullOrEmpty(title.Text))
            {
                Response.Redirect("~/DiaryList");
            }

            DiaryData diaryData = new DiaryData();
            diaryData.OwnerName = Session["Username"].ToString();
            diaryData.Date = DateTime.Now;
            diaryData.Title = title.Text;
            diaryData.Class = @class.Text;
            diaryData.Journal = journal.Text;

            Global.dbmanager.AddDiary(Session["Username"].ToString(),diaryData);

            Response.Redirect("~/DiaryList");
        }

        protected void CancelButton_Click(object sender,EventArgs e)
        {
            Response.Redirect("~/DiaryList");
        }
    }
}