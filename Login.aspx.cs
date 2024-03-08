using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Diary
{
    public partial class Login : System.Web.UI.Page
    {
        Authentication authentication = new Authentication();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("(debug)[Login.PageLoad]start");
            Session["username"] = null;      
            

        }
        protected void LoginButton_Click(object sender,EventArgs e)
        {
            if (authentication.AuthenticateUser(UsernameInput.Text,PasswordInput.Text))
            {
                Session["username"] = UsernameInput.Text;
                for (int i = 0;i < Global.dbmanager.listUserData.Count; i++)
                {
                    if (Global.dbmanager.listUserData[i].Username == Session["username"].ToString())
                    {
                        Session["Usergroup"] = Global.dbmanager.listUserData[i].Usergroup;
                        break;
                    }
                    if(i >= Global.dbmanager.listUserData.Count - 1)
                    {
                        Debug.WriteLine("(error)[Login.LoginButton_Click]username is not found in listUserData");
                    }
                }
                Response.Redirect("Home");
            }
            else
            {
                PasswordInput.Text = null;
            }
        }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            //已存在同樣名字的使用者
            if (!authentication.RegisterUser(RegisterusernameInput.Text, RegisterpasswordInput.Text)) Response.Redirect("Login#register");
            else
            {
                RegisterusernameInput.Text = null;

                RegisterpasswordInput.Text = null;
                RegisterpasswordcheckInput.Text = null;
            }
        }
        
    }
}