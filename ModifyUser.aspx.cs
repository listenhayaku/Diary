using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;   //手動增加 為了Regex


namespace Diary
{
    public partial class ModifyUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["Usergroup"].ToString() != "0") Response.Redirect("Home");



            //表格，但我現在想嘗試gridview
            /*int numrows = dbmanager.listUserData.Count;
            for (int j = 0; j < numrows; j++)
            {
                TableRow r = new TableRow();
                TableCell cId = new TableCell();
                TableCell cGroup = new TableCell();
                TableCell cUsername = new TableCell();
                TableCell cPassword = new TableCell();
                TableCell cIdcontent = new TableCell();
                TableCell cGroupcontent = new TableCell();
                TableCell cUsernamecontent = new TableCell();
                TableCell cPasswordcontent = new TableCell();

                cId.Controls.Add(new LiteralControl("Id"));
                cGroup.Controls.Add(new LiteralControl("Group"));
                cUsername.Controls.Add(new LiteralControl("Username"));
                cPassword.Controls.Add(new LiteralControl("Password"));
                cIdcontent.Controls.Add(new LiteralControl(dbmanager.listUserData[j].Id.ToString()));
                cGroupcontent.Controls.Add(new LiteralControl(dbmanager.listUserData[j].Group.ToString()));
                cUsernamecontent.Controls.Add(new LiteralControl(dbmanager.listUserData[j].Username.ToString()));
                cPasswordcontent.Controls.Add(new LiteralControl(dbmanager.listUserData[j].Password.ToString()));

                r.Cells.Add(cId);
                r.Cells.Add(cIdcontent);
                r.Cells.Add(cGroup);
                r.Cells.Add(cGroupcontent);
                r.Cells.Add(cUsername);
                r.Cells.Add(cUsernamecontent);
                r.Cells.Add(cPassword);
                r.Cells.Add(cPasswordcontent);
                UserData.Rows.Add(r);
            }*/
        }

        protected void ModifySubmitButton_Click(object sender,EventArgs e)
        {
            //Debug.WriteLine("(debug)[ModifySubtmiButton]donkey"+Request["User1"]);
            //利用try catch方法找到資料最後一筆
            for(int i = 0;i < Global.dbmanager.listUserData.Count; i++)
            {
                //Debug.WriteLine("(debug)[ModifySubmitButton_Click]i:" + i);
                try
                {
                    if (Request[$"UserPermission{i}"] !="" || Request[$"Password{i}"] != "")
                    {
                        int Id = int.Parse(Request[$"UserId{i}"]);
                        string Username = Request[$"Username{i}"];
                        for(int j = 0;j < Global.dbmanager.listUserData.Count; j++)
                        {
                            //資料沒問題 確定可以開始處理
                            if (Global.dbmanager.listUserData[j].Id == Id && Global.dbmanager.listUserData[j].Username == Username)
                            {
                                //修改權限
                                if (Request[$"UserPermission{i}"] != "")
                                {
                                    int Usergroup = int.Parse(Request[$"UserPermission{i}"]);
                                    Global.dbmanager.listUserData[j].Usergroup = Usergroup;
                                    Global.dbmanager.ModifyUsergroup(Id, Username, Usergroup);
                                }
                                //修改密碼
                                if (Request[$"Password{i}"] != "")
                                {
                                    string Password = Request[$"Password{i}"];
                                    Global.dbmanager.listUserData[j].Password = Password;
                                    Global.dbmanager.ModifyPassword(Id, Username, Password);
                                }
                            }
                            //ID與username不同 資料有問題
                            else if ((Global.dbmanager.listUserData[j].Id == Id && Global.dbmanager.listUserData[j].Username != Username) || (Global.dbmanager.listUserData[j].Id != Id && Global.dbmanager.listUserData[j].Username == Username))
                            {
                                Global.dbmanager.LoadUserData();
                            }
                        }

                    }

                    //Debug.WriteLine("(debug)[ModifySubmitButton_Click]Request" + i + ":" + Request["User" + i]);
                    //下拉是選單沒有值代表沒有更改
                    //這邊是權限有改
                    /*if (Request[$"UserPermission{i}"] != "")
                    {

                        int Usergroup = int.Parse(Request[$"UserPermission{i}"]);
                        //Debug.WriteLine($"(debug)[ModifySubmitButton]User{i} has been changed value:{Request[$"UserPermission{i}"]}");
                        Debug.WriteLine($"(debug)[ModifyUserButton_Click]Username:{Username}");
                        for(int j = 0;j < Global.dbmanager.listUserData.Count; j++)
                        {
                            if (Username == Global.dbmanager.listUserData[j].Username)
                            {
                                if (int.Parse(Request[$"UserId{i}"]) == Global.dbmanager.listUserData[j].Id)
                                {
                                    Debug.WriteLine($"(debug)[ModifyUserButton_Click]confirm to change id:{Request[$"UserId{i}"]},Username:{Username};Permission changed from{Global.dbmanager.listUserData[j].Usergroup} to {Usergroup}");
                                    Global.dbmanager.ModifyUsergroup(Id,Username,Usergroup);
                                }
                                else
                                {
                                    Debug.WriteLine($"(exception)[ModifyUserButton_Click]Username is different to Id;i:{i},j:{j}");
                                    //throw (new Exception($"(exception)[ModifyUserButton_Click]Username is different to Id;i:{i},j:{j}"));
                                }
                            }
                            else
                            {
                                Debug.WriteLine("(debug)[ModifyUserButton_Click]not" + j);
                            }
                        }
                    }*/
                }
                catch(Exception exception)
                {
                    Debug.WriteLine("(deubg)[ModifyUserButton_Click]exception request data end");
                    break;
                }
                finally
                {
                   
                }
            }
        }
        protected void ModifyCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ModifyUser");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            StringWriter output = new StringWriter();
            base.Render(new HtmlTextWriter(output));
            string outputAsString = output.ToString();
            string rowtemplate;
            //改寫區
            //(?=(<tbody>)\s+)?(.+\s+)?(?=(<\/tbody>)) 太感動了 這個可以擷取 <tbody>空白換行 跟 空白換行</tbody>之間的內容 就是我們要的 <tr><td>@Id</td><td>@Group</td><td>@Username</td><td>@Password</td></tr>
            //rowtemplate = Regex.Match(outputAsString, "(?=(<tbody>)\\s+)?(.+\\s+)?(?=(<\\/tbody>))").ToString();
            rowtemplate = Regex.Match(outputAsString, Global.myconfigmanager.listMyConfig[0].RegexModifyUser).ToString();
            //outputAsString = Regex.Replace(outputAsString, "((<tbody>)\s+)(\S+)(\s+(<\/tbody>))","$1 = hello");
            for (int i = 0;i < Global.dbmanager.listUserData.Count; i++)
            {
                outputAsString = outputAsString.Replace("@Id@", Global.dbmanager.listUserData[i].Id.ToString());
                outputAsString = outputAsString.Replace("@Num@",i.ToString());
                if (Global.dbmanager.listUserData[i].Usergroup == 0)
                {
                    outputAsString = outputAsString.Replace("@Group@", "管理員");
                    outputAsString = outputAsString.Replace("@Group2@", "一般使用者");
                    outputAsString = outputAsString.Replace("@Value@", "0");
                    outputAsString = outputAsString.Replace("@Value2@", "1");
                }
                else if (Global.dbmanager.listUserData[i].Usergroup == 1)
                {
                    outputAsString = outputAsString.Replace("@Group@", "一般使用者");
                    outputAsString = outputAsString.Replace("@Group2@", "管理員");
                    outputAsString = outputAsString.Replace("@Value@", "1");
                    outputAsString = outputAsString.Replace("@Value2@", "0");
                }
                else outputAsString = outputAsString.Replace("@Group@", "群組代號錯誤");

                outputAsString = outputAsString.Replace("@Username@", Global.dbmanager.listUserData[i].Username);
                outputAsString = outputAsString.Replace("@Password@", Global.dbmanager.listUserData[i].Password);
                //會多新增一行
                outputAsString = outputAsString.Replace("</tbody>", rowtemplate + "\n</tbody>");
            }
            //要將最後多新增的一行rowtemplate刪掉
            outputAsString = outputAsString.Replace(rowtemplate, "");
            //改寫區
            //Debug.WriteLine("(debug)[modifyuser.render]rowtemplate:\n"+rowtemplate);
            writer.Write(outputAsString);
        }
    }
}