using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class ObjectList_Partial : System.Web.UI.UserControl
    {
        protected List<ObjectData> listObjectData = new List<ObjectData>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null) Response.Redirect("~/Login");

            Global.dbmanager.RetreiveObjectData(Session["Username"].ToString(),ref listObjectData);
        }
    }
}