﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.Model;

namespace SSTUCloud
{
	public partial class Degrees : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string serializedString = JSONParser.Instance.Serialize(Degree.GetDegreesList());

			Response.Write(serializedString);
		}
	}
}