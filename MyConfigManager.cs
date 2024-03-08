using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Diary
{
    public class MyConfigManager : Page
    {
        private string dir; //專案位置

        public List<MyConfig> listMyConfig = new List<MyConfig>();
        public MyConfigManager()
        {
            ReadMyConfig();
        }
        private bool ReadMyConfig()
        {
            dir = Server.MapPath(".");
            using (StreamReader r = new StreamReader(dir + @"\MyConfig.json"))
            {
                string json = r.ReadToEnd();
                //Debug.WriteLine(json);
                MyConfig myconfig = new MyConfig();
                listMyConfig = JsonConvert.DeserializeObject<List<MyConfig>>(json);
            }
            return true;
        }
    }
}