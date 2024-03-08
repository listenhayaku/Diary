using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login");
            }
        }
        protected void Page_PreRender(object sender,EventArgs e)
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            StringWriter output = new StringWriter();
            base.Render(new HtmlTextWriter(output));
            //This is the rendered HTML of your page. Feel free to manipulate it.
            string outputAsString = output.ToString();

            //改寫區
            outputAsString = outputAsString.Replace("@User", Session["username"].ToString());
            //改寫區
            writer.Write(outputAsString);
        }

        protected void DiaryListButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DiaryList");
        }
        protected void DiaryEditorButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DiaryEditor");
        }
    }
}