using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DAL.Model
{
	public class TeachingForm
	{
		public enum TeachingForms
		{
			[Description("Очная")]
			FullTime = 0,

			[Description("Очно-заочная")]
			PartTime = 1,

			[Description("Заочная")]
			Extramural = 2,

			[Description("Заочно-сокращенная")]
			ExtramuralAbbreviated = 3,
			
			[Description("Сокращенная")]
			Abbreviated = 4
		}

		private static List<TeachingForm> _teachingForms; 

		public int ID;
		public string Name;

		public TeachingForm(int id, string name)
		{
			ID = id;
			Name = name;
		}

		public static List<TeachingForm> GetTeachingFormsList()
		{
			if (_teachingForms == null)
			{
				_teachingForms = new List<TeachingForm>();

				foreach (var value in Enum.GetValues(typeof(TeachingForms)))
				{
					_teachingForms.Add(new TeachingForm((int)value, value.GetDescription()));
				}
			}

			return _teachingForms;
		} 

		public static TeachingForms GetTeachingFormForGroupNamed(string groupName)
		{
			var teachingForm = TeachingForms.FullTime;

			if (groupName.Length > 0)
			{
				char firstLetter = groupName[0];

				switch (firstLetter)
				{
					case 'с':
						teachingForm = TeachingForms.PartTime;
						break;

					default:
						teachingForm = TeachingForms.FullTime;
						break;
				}
			}

			return teachingForm;
		}
	}
}
