using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Diary
{
	public class DiaryData
	{
		public int Id { get; set; }
		public int OwnerId { get; set; }
		public string OwnerName { get; set; }
		public DateTime Date { get; set; }
		public string Title { get; set; }
		public string Class { get; set; }
		public string Journal { get; set; }
		public bool Show()
		{
			Debug.WriteLine("(debug)[DiaryData.Show]Id:" + Id);
			Debug.WriteLine("(debug)[DiaryData.Show]OwnerId:" + OwnerId);
			Debug.WriteLine("(debug)[DiaryData.Show]OwnerName:" + OwnerName);
			Debug.WriteLine("(debug)[DiaryData.Show]Date:"+Date);
			Debug.WriteLine("(debug)[DiaryData.Show]Title:" + Title);
			Debug.WriteLine("(debug)[DiaryData.Show]Class:" + Class);
			Debug.WriteLine("(debug)[DiaryData.Show]Journal:" + Journal);

			return true;
		}
	}
}
