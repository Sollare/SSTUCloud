using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JsonFx.Json;
using DAL;

namespace SSTUCloud
{
	public partial class TeachersList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			List<Teacher> teachers = null;
			try
			{
				teachers = Teacher.GetAllTeachers();
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
				Console.WriteLine(ex.Message);
			}

			string serializedString = JSONParser.Instance.Serialize(teachers);
			
			Response.Write(serializedString);
		}
	}
}