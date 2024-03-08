using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;

namespace Diary
{
    public class UserData
    {

        public int Id { get; set; }
        public int Usergroup { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public bool Show()
        {
            Debug.WriteLine("[UserData.Show]Id:" + this.Id + "|Group:" + this.Usergroup + "|Username:" + this.Username + "|Password:" + Password);
            return true;
        }
    }
}
