using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Diary
{
    public class ObjectData
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public DateTime Datetime { get; set; }  //建立時間 其實應該是不需要這個 保留使用
        public string Name { get; set; }
        public Dictionary<string,string> Description { get; set; }

        public void Show()
        {
            Debug.WriteLine("(debug)[ObjectData.Show]start");

            Debug.WriteLine($"(debug)[ObjectData.Show]Id:{Id},OwnerId:{OwnerId},OwnerName:{OwnerName},Datetime{Datetime},Name{Name},Description:");
            foreach (KeyValuePair<string, string> kvp in Description)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Debug.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
            Debug.WriteLine("(debug)[ObjectData.Show]end");
        }
    }
}