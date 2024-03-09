using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Diary
{
    public class MyConfig
    {
        public string ConfigVersion { get; set; }
        public string AuthorName { get; set; }
        public int AuthorAge { get; set; }
        public string DbNameUserData {get;set;}
        public string DbNameDiaryData { get; set; }
        public string DbNameObjectData { get; set; }
        public string RegexModifyUser { get; set; }

        public bool Show()
        {
            Debug.WriteLine("(debug)[MyConfig.Show]ConfigVersion:" + ConfigVersion);
            Debug.WriteLine("(debug)[MyConfig.Show]AuthorName:"+AuthorName);
            Debug.WriteLine("(debug)[MyConfig.Show]AuthorAge:"+AuthorAge);
            Debug.WriteLine("(debug)[MyConfig.Show]DbNameUserData:" + DbNameUserData);
            Debug.WriteLine("(debug)[MyConfig.Show]DbNameUserData:" + DbNameDiaryData);
            Debug.WriteLine("(debug)[MyConfig.Show]DbNameUserData:" + DbNameObjectData);
            Debug.WriteLine("(debug)[MyConfig.Show]RegexModifyUser:" + RegexModifyUser);
            return true;
        }
    }
}
