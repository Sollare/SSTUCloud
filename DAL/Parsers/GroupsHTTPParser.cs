using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DAL.Model;

namespace DAL.Parsers
{
	public class GroupsHTTPParser : HTTPParser<Group>
	{
		const string Pattern = "<a .*?GROUP=(\\d*).*?>([а-яА-Я\\d ]*)</a>";

		public override List<Group> ParseEntitiesFromCode(string htmlCode) 
		{
			var groups = new List<Group>();

			var regex = new Regex(Pattern);
			var matcher = regex.Matches(htmlCode);

			for (int i = 0; i < matcher.Count; i++)
			{
				int id;

				if (int.TryParse(matcher[i].Groups[1].ToString(), out id))
				{
					string name = matcher[i].Groups[2].ToString();

					Degree.Degrees degree = Degree.GetDegreeForGroupNamed(name);
					TeachingForm.TeachingForms form = TeachingForm.GetTeachingFormForGroupNamed(name);

					groups.Add(new Group(id, name, degree, form));
				}
				else
					groups.Add(new Group(-1, "ABC", Degree.Degrees.Postgraduation, TeachingForm.TeachingForms.ExtramuralAbbreviated));
				//throw new Exception("Не удалось распознать ID группы");
			}


			return groups;
		}
	}
}
