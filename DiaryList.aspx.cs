using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class DiaryList : System.Web.UI.Page
    {
        protected List<DiaryData> listDiaryData = new List<DiaryData>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null) Response.Redirect("/Login");


            Global.dbmanager.RetreiveDiaryData(Session["Username"].ToString(), ref listDiaryData);
            if (Request.HttpMethod == "GET")
            {
                //Debug.WriteLine("(debug)[DiaryList.Page_Load]get");
            }
            else if(Request.HttpMethod == "POST")
            {
                //Debug.WriteLine("(debug)[DiaryList.Page_Load]post");
                //Debug.WriteLine($"(debug)[DiaryList.Page_Load]Request[\"_id\"]:{Request["_id"]},Request[\"_del\"]:{Request["_del"]}");
                if (Request["_del"].ToString() == "true")
                {
                    //Debug.WriteLine("(debug)[DiaryList.Page_Load]del == true");
                    DiaryData diaryData = new DiaryData();
                    try
                    {
                        diaryData = listDiaryData[int.Parse(Request["_id"])];
                        Global.dbmanager.DeleteDiary(diaryData); //在這之前不會載入日記。其實我一值擔心如果開其他葉面處理刪除這個動作，就必須在其他class底下做這件事情，那就得重新讀取，我擔心會有更動導致想要刪除的文章當時id與新的不同   //破功了 每次近來都會重置 所以還是一樣會重新載入

                        Global.dbmanager.RetreiveDiaryData(Session["Username"].ToString(), ref listDiaryData);
                    }
                    finally
                    {
                        Response.Redirect("~/DiaryList");   //避免想要重新整理的時候跳出重新提交表單
                    }

                }
            }
            else
            {
                //Debug.WriteLine("(debug)[DiaryList.Page_Load]not get or post");
            }
            
        }
        protected void NewDiaryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewDiary");
        }
        protected void test_Click(object sender,EventArgs e)
        {
            Response.Redirect("~/Login");
        }
    }
}