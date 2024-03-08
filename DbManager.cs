using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Diary
{
    public class DbManager
    {

        public List<UserData> listUserData = new List<UserData>();
        public List<DiaryData> listDiaryData = new List<DiaryData>();   //我在思考要不要全部導入到記憶體再分，這樣不會有sql injection但是對Server負擔應該不小
        private int UserNextId; //目前只有做建構函數初始，之後每次修改應該都要確認否則估計會有問題
        private int DiaryNextId;
        public DbManager()
        {
            LoadUserData();
            LoadDiaryData();
        }
        public bool LoadUserData()
        {
            //資料庫的ID不一定是連續的因為會有修改刪除的狀況，所以用兩個 一個紀錄數量 一個紀錄最大ID 取大的+1給UserNextId
            int Maxid = 0;
            int Count = 0;
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["DbConnectionString"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new Exception("Fatal error: missing connecting string in web.config file");

            SqlConnection conn = new SqlConnection(mySetting.ConnectionString.ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from UserData;", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                listUserData.Clear();
                while (dr.Read())
                {
                    UserData userData = new UserData();
                    //我也不知道為什麼 提取int要這樣用
                    //https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader
                    userData.Id = dr.GetInt32(0);
                    userData.Usergroup = dr.GetInt32(1);
                    //userData.Username = dr.GetString(2);  //這個也可以 看起來比較統一
                    userData.Username = dr[2].ToString();
                    userData.Password = dr[3].ToString();
                    listUserData.Add(userData);

                    Maxid = (Maxid > userData.Id) ? Maxid : userData.Id;
                    Count++;
                }
                UserNextId = ((Maxid > Count) ? Maxid : Count) + 1;
                return true;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }

        }
        public bool AddUser(string Username,string Password)
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["DbConnectionString"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new Exception("Fatal error: missing connecting string in web.config file");

            SqlConnection conn = new SqlConnection(mySetting.ConnectionString.ToString());
            conn.Open();
            int id = UserNextId;
            UserNextId++;
            int group = 1;
            string username = Username;
            string password = Password;

            string stringSqlCmd = $"INSERT INTO UserData VALUES ({id},{group},'{username}','{password}');";
            SqlCommand cmd = new SqlCommand(stringSqlCmd, conn);
            //Debug.WriteLine("[DbManager.Exec]exec sqlcmd:" + stringSqlCmd);
            cmd.ExecuteReader();
            conn.Close();
            LoadUserData();
            return true;
        }
        public bool ModifyUsergroup(int Id,string Username,int newGroup)    //同時要id跟username拿來驗證資料是否有誤
        {
            for(int i = 0;i < listUserData.Count; i++)
            {
                if(listUserData[i].Id == Id && listUserData[i].Username == Username)
                {
                    //記憶體
                    listUserData[i].Usergroup = newGroup;
                    //資料庫
                    string cmd = $"UPDATE UserData SET Usergroup={newGroup} WHERE Id={Id} AND Username=\'{Username}\';";
                    Exec(cmd);
                    return true;
                }
                else if ((listUserData[i].Id == Id && listUserData[i].Username != Username) || (listUserData[i].Id != Id && listUserData[i].Username == Username))
                {
                    Debug.WriteLine("(error)[dbmanager.ModifyGroup]incorrect data");
                    return false;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
        public bool ModifyPassword(int Id, string Username, string newPassword)    //同時要id跟username拿來驗證資料是否有誤
        {
            for (int i = 0; i < listUserData.Count; i++)
            {
                if (listUserData[i].Id == Id && listUserData[i].Username == Username)
                {
                    //記憶體
                    listUserData[i].Password = newPassword;
                    //資料庫
                    string cmd = $"UPDATE UserData SET Password=\'{newPassword}\' WHERE Id={Id} AND Username=\'{Username}\';";
                    Exec(cmd);
                    return true;
                }
                else if ((listUserData[i].Id == Id && listUserData[i].Username != Username) || (listUserData[i].Id != Id && listUserData[i].Username == Username))
                {
                    Debug.WriteLine("(error)[dbmanager.ModifyPassword]incorrect data");
                    return false;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        //將db的所有日記載入到記憶體
        public bool LoadDiaryData()
        {
            //資料庫的ID不一定是連續的因為會有修改刪除的狀況，所以用兩個 一個紀錄數量 一個紀錄最大ID 取大的+1給UserNextId
            int Maxid = 0;
            int Count = 0;
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["DbConnectionString"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new Exception("Fatal error: missing connecting string in web.config file");

            SqlConnection conn = new SqlConnection(mySetting.ConnectionString.ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from {Global.myconfigmanager.listMyConfig[0].DbNameDiaryData};", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                listDiaryData.Clear();
                while (dr.Read())
                {
                    DiaryData diaryData = new DiaryData();
                    //我也不知道為什麼 提取int要這樣用
                    //https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader
                    diaryData.Id = dr.GetInt32(0);
                    diaryData.OwnerId = dr.GetInt32(1);
                    //diaryData.Username = dr.GetString(2);  //這個也可以 看起來比較統一
                    diaryData.OwnerName = dr.GetString(2);
                    diaryData.Date = dr.GetDateTime(3);
                    diaryData.Title = dr.GetString(4);
                    diaryData.Class = dr.GetString(5);
                    diaryData.Journal = dr[6].ToString();
                    listDiaryData.Add(diaryData);

                    Maxid = (Maxid > diaryData.Id) ? Maxid : diaryData.Id;
                    Count++;
                }
                DiaryNextId = ((Maxid > Count) ? Maxid : Count) + 1;
                return true;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }

        }
        public bool AddDiary(string OwnerName,DiaryData diaryData)
        {
            diaryData.Id = DiaryNextId;
            DiaryNextId++;
            Exec($"INSERT INTO DiaryData VALUES ({diaryData.Id},{diaryData.OwnerId},'{diaryData.OwnerName}','{diaryData.Date.ToString("yyyy-MM-dd hh:mm:ss")}','{diaryData.Title}','{diaryData.Class}','{diaryData.Journal}');");
            return true;
        }
        //輸入username 跟id(日記相對id 代表這個作者的第幾篇)
        public bool UpdateDiary(int Id,DiaryData newdiaryData)
        {
            Exec($"UPDATE DiaryData SET title='{newdiaryData.Title}',class='{newdiaryData.Class}',journal='{newdiaryData.Journal}' WHERE id={Id};");
            return true;
        }
        public bool DeleteDiary(DiaryData diaryData)
        {
            this.listDiaryData.Remove(diaryData);
            Exec($"DELETE FROM DiaryData WHERE id={diaryData.Id};");
            LoadDiaryData();
            return true;
        }
        public bool RetreiveDiaryData(string OwnerName,ref List<DiaryData> listDiaryData)
        {
            listDiaryData.Clear();
            LoadDiaryData();
            for(int i = 0;i < this.listDiaryData.Count; i++)
            {
                if (this.listDiaryData[i].OwnerName == OwnerName) listDiaryData.Add(this.listDiaryData[i]);
            }
            return true;
        }
        private void Exec(String stringSqlCmd)
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["DbConnectionString"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new Exception("Fatal error: missing connecting string in web.config file");

            SqlConnection conn = new SqlConnection(mySetting.ConnectionString.ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(stringSqlCmd, conn);
            Debug.WriteLine("[DbManager.Exec]exec sqlcmd:" + stringSqlCmd);
            cmd.ExecuteReader();
            conn.Close();
        }
    
    }
}