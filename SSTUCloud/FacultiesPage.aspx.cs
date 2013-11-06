using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SSTUCloud
{
	public partial class FacultiesPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string serializedString = JSONParser.Instance.Serialize(Faculty.GetFacultiesList());

			Response.Write(serializedString);
		}
	}
}