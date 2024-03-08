using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class MySite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void Render(HtmlTextWriter writer)
        {
            StringWriter output = new StringWriter();
            base.Render(new HtmlTextWriter(output));
            //This is the rendered HTML of your page. Feel free to manipulate it.
            string outputAsString = output.ToString();

            //改寫區
            if (Session["username"] != null) outputAsString = outputAsString.Replace("登入", "登出");
            if (Session["username"] == null || Session["Usergroup"].ToString() != "0")
            {
                outputAsString = outputAsString.Replace("修改權限", "");
            }
            //改寫區
            writer.Write(outputAsString);
        }
    }
}