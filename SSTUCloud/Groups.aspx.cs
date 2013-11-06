using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SSTUCloud
{
	public partial class Groups : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var facultyIdString = Request.QueryString["Faculty"];

			if (facultyIdString != null)
			{
				int facultyId;
				if (int.TryParse(facultyIdString, out facultyId))
				{
					try
					{
						var faculty = Faculty.GetFacultyForId(facultyId);
						var groups = Faculty.GetGroupsFor(faculty);

						string serializedString = JSONParser.Instance.Serialize(groups);

						Response.Write(serializedString);
					}
					catch (Exception ex)
					{
						Response.Write("Ошибка:\n" + ex.Message);
						return;
					}
				}
				else Response.Write("Не удалось распознать Id факультета");
			}
			else
			{
				Response.Write("Необходимо указать Id факультета");
			}
		}
	}
}