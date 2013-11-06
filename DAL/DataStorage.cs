using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Model;
using DAL.Parsers;

namespace DAL
{
	/// <summary>
	/// Здесь хранится и отсюда извлекается вся необходимая информация.
	/// </summary>
	static class DataStorage
	{
		public static List<T> GetListOf<T>()
		{
			// Извлекает и отдает
			throw new ArgumentNullException();
		}
		
		public static List<Group> FetchGroupsForFaculty(Faculty faculty)
		{
			if (faculty == null)
			{
				Console.WriteLine("Факультет не указан (NULL)");
				return null;
			}

			List<Group> groups;
			int facultyId = faculty.ID;
			var parser = new GroupsHTTPParser();

			string facultyGroupsUrl = HTTPGetter.GetGroupsUrlForFacultyId(facultyId);
			string htmlCode = HTTPGetter.GetCodeOfPage(facultyGroupsUrl);

			groups = parser.ParseEntitiesFromCode(htmlCode);

			return groups;
		}
	}
}
