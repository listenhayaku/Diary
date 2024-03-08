using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;

namespace Diary
{
    public class Authentication : IHttpModule
    {
        /// <summary>
        /// 您將需要在您 Web 的 Web.config 檔中設定此模組，
        /// 並且向 IIS 註冊該處理程式，才能使用它。如需詳細資訊，
        /// 參閱下列連結: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule 成員

        public void Dispose()
        {
            //清理程式碼在這裡。
        }

        public void Init(HttpApplication context)
        {
            // 以下是您能夠如何處理 LogRequest 事件的範例，並提供
            // 它的自訂記錄實作
            context.LogRequest += new EventHandler(OnLogRequest);
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //自動記錄邏輯在這裡
        }


        public bool AuthenticateUser(String Username,String Password)
        {
            /*UserData[] arrayUserData = new UserData[] { };
            UserData tempUserData = new UserData();
            tempUserData.Id = 0;
            tempUserData.Group = 1;
            tempUserData.Username = "Carl";
            tempUserData.Password = "123";
            arrayUserData.Add(tempUserData);*/


            String password;
            //
            SqlConnection conn = new SqlConnection("data source=localhost\\SQLEXPRESS; initial catalog=Diary; user id=sa; password=admin");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from UserData where username=\'"+Username+"\';", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    password = dr[3].ToString();    //這邊如果後方出現多於空格，db可能要改成varchar
                    if (password == Password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            finally
            {
                dr.Close();
            }
            //
        }
        public bool RegisterUser(String Username,String Password)
        {
            //找資料庫此名稱是否已經存在
            for(int i = 0;i < Global.dbmanager.listUserData.Count; i++)
            {
                //找到
                if(Username == Global.dbmanager.listUserData[i].Username) return false;
            }
            Global.dbmanager.AddUser(Username, Password);
            return true;
        }
    }
}
