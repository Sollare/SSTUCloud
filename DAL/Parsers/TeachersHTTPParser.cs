using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DAL;

namespace DAL.Parsers
{
	public class TeachersHTTPParser: HTTPParser<Teacher>
	{
		public override List<Teacher> ParseEntitiesFromCode(string htmlCode)
		{
			var teachers = new List<Teacher>();

			Regex regex = new Regex("<a .*?PREP=(\\d*).*?color=\"#\\d*\">([а-яА-Я ]*)");
            MatchCollection matcher = regex.Matches(htmlCode);
			
			for (int i = 0; i < matcher.Count; i++)
			{
				try
				{
					teachers.Add(new Teacher(matcher[i].Groups[1].ToString(), matcher[i].Groups[2].ToString()));
				}
				catch (Exception e)
				{
					Console.WriteLine("Ошибка парсинга строки преподавателя");
				}
			}

			return teachers;
		}
	}
}
