using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class DiaryContent : System.Web.UI.Page
    {
        protected List<DiaryData> listDiaryData = new List<DiaryData>();
        protected DiaryData diaryData = new DiaryData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null) Response.Redirect("Login");


            Global.dbmanager.RetreiveDiaryData(Session["Username"].ToString(), ref listDiaryData);
            Debug.WriteLine("(debug)[DiaryContent.Page_Load]Request:" + Request["id"]);
            //因為request是前端就可以更改的url 可能不是我們預期的 "DiaryContent?id={num}" 所以如果無法解析或是值太奇怪(超出應有長度) 發生錯誤直接跳轉
            try
            {
                diaryData = listDiaryData[int.Parse(Request["id"])];
            }
            catch(Exception exception)
            {
                //throw exception;
                Debug.WriteLine("(debug)[DiaryContent.Page_Load]Exception");
                Response.Redirect("~/DiaryContentNotExist");
            }
            if (!IsPostBack)
            {
                FrontTitle.Text = diaryData.Title;
                FrontJournal.Text = diaryData.Journal;
            }
        }
        protected void ModifyButton_Click(object sender,EventArgs e)
        {
            if(Request.HttpMethod == "POST")
            {
                Debug.WriteLine($"(debug)[ModifyButton_Click]method is not get,Request[\"id\"]:{Request["id"]}");
                int RelativeId; //相對ID
                int Id;//日記絕對id
                DiaryData newdiaryData = new DiaryData();
                RelativeId = int.Parse(Request["id"]);
                Id = listDiaryData[RelativeId].Id;
                newdiaryData = listDiaryData[RelativeId];
                newdiaryData.Title = FrontTitle.Text;
                newdiaryData.Journal = FrontJournal.Text;
                newdiaryData.Show();

                Global.dbmanager.UpdateDiary(Id,newdiaryData);
            }
            else
            {
                Debug.WriteLine("(debug)[ModifyButton_Click]method isget");
            }
            Response.Redirect("~/DiaryList");
        }
        protected void BacktoListButton_Click(object sender,EventArgs e)
        {
            Response.Redirect("/DiaryList");
        }


    }
}