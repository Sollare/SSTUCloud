using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DAL
{
	public class HTTPGetter
	{
		/// <summary>
		/// http://rasp.sstu.ru
		/// </summary>
		public static string RootUrl = @"http://rasp.sstu.ru";
		public static string TeachersUrl = RootUrl + @"/SelPrep.aspx?OLD=0";
		public static string GetGroupsUrlForFacultyId(int facultyId)
		{
			return string.Concat(RootUrl, "/SelSpec.aspx?FAK=", facultyId, "&OLD=0");
		}

		public static string GetCodeOfPage(string @url) 
		{
			HttpWebRequest req;
			HttpWebResponse resp;
			StreamReader sr;
			string content;

			req = (HttpWebRequest)WebRequest.Create(@url);
			resp = (HttpWebResponse)req.GetResponse();
			sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("utf-8"));
			content = sr.ReadToEnd();
			sr.Close();

			return content;
		}
	}
}
