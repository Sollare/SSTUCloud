using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL.Parsers;

namespace DAL
{
	public class Faculty
	{
		public int ID;
		//public string ShortName;
		public string Name;

		private static List<Faculty> Faculties;

		/// <summary>
		/// Словарь идФакультета-группы
		/// </summary>
		private static readonly Dictionary<int, List<Group>> FacultyGroupDictionary = new Dictionary<int, List<Group>>(); 

		public string GetID()
		{
			return (ID < 10) ? string.Concat("0", ID) : ID.ToString();
		}

		public Faculty(int id, string shortName, string name)
		{
			ID = id;
			//ShortName = shortName;
			Name = name;
		}

		public static List<Faculty> GetFacultiesList()
		{
			if (Faculties == null)
			{
				Faculties = new List<Faculty>
					{
						new Faculty(01, "Автомех", "Автомеханический факультет"),
						new Faculty(16, "САДИ", "Строительно-архитектурно-дорожный институт"),
						new Faculty(18, "ИНЭТМ", "Институт электронной техники и машиностроения"),
						new Faculty(17, "ФТФ", "Физико-технический факультет"),
						new Faculty(13, "СГФ", "Социально-гуманитарный факультет"),
						new Faculty(08, "ФЭМ", "Факультет экономики и менджмента"),
						new Faculty(07, "ФЭС", "Факультет экологии и сервиса"),
						new Faculty(11, "МФПИТ", "Международный факультет прикладных информационных технологий"),
						new Faculty(06, "ЭФ", "Энергетический факультет")
					};
			}
			else
			{
				
			}

			return Faculties;
		}

		public static Faculty GetFacultyForId(int facultyId)
		{
			return GetFacultiesList().First(faculty => faculty.ID == facultyId);
		}

		public static List<Group> GetGroupsFor(Faculty faculty)
		{
			try
			{
				int facultyId = faculty.ID;

				List<Group> groups;
				if (FacultyGroupDictionary.TryGetValue(facultyId, out groups))
					return groups;
				else
				{
					groups = DataStorage.FetchGroupsForFaculty(faculty);

					if (groups == null)
						throw new DataException();

					FacultyGroupDictionary.Add(faculty.ID, groups);

					return groups;
				}
			}
			catch (ArgumentOutOfRangeException e)
			{
				e.Message.Insert(0, "Неверный Id факультета: " + faculty.ID + "\n");
				throw;
			}
			catch (DataException e)
			{
				e.Message.Insert(0, "Не удалось получить список групп для факультетов для факультета: " + faculty.ID + "\n");
				throw;
			}
			catch (NullReferenceException e)
			{
				if(faculty == null)
					e.Message.Insert(0, "Невозможно получить список групп для факультета null\n");

				throw;
			}
		}
	}
}
