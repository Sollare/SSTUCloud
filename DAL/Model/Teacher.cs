using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Parsers;

namespace DAL
{
	public class Teacher
	{
		public string ID;
		public string Name;

		public Teacher(string id, string name)
		{
			ID = id;
			Name = name;
		}

		private static List<Teacher> Teachers;

		public static List<Teacher> GetTeachersInRange(int startIndex, int count)
		{
			if (Teachers == null) RefreshTeachersList();

			if (startIndex < 0)
				throw new Exception("start index is less than 0");

			if (startIndex >= Teachers.Count)
				throw new Exception("start index more then count of teachers in list");

			if (count < 0)
				throw new Exception("count is less then 0");

			if (startIndex + count > Teachers.Count) count = Teachers.Count - startIndex;

			return Teachers.GetRange(startIndex, count);
		}

		public static List<Teacher> GetAllTeachers()
		{
			return Teacher.GetTeachersInRange(0, Teachers.Count);
		}

		public static void RefreshTeachersList()
		{
			HTTPParser<Teacher> parser = new TeachersHTTPParser();
			string htmlCode;
			string url = HTTPGetter.TeachersUrl;

			try
			{
				htmlCode = HTTPGetter.GetCodeOfPage(url);
			}
			catch
			{
				Teachers = new List<Teacher>();
				Console.WriteLine("Ошибка получения кода страницы");
				return;
			}

			try
			{
				Teachers = parser.ParseEntitiesFromCode(htmlCode);
			}
			catch
			{

				Teachers = new List<Teacher>();
				Console.WriteLine("Ошибка парсинга");
				return;
			}

			Teachers = (from teacher in Teachers orderby teacher.Name select teacher).ToList();
		}

		
	}
}
