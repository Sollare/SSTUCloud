using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DAL.Model
{
	public class Degree
	{
		public enum Degrees
		{
			[Description("Специалитет")]
			Specialty = 0,

			[Description("Бакалавр")]
			Bachelor = 1,

			[Description("Магистратура")]
			Magistracy = 2,

			[Description("Аспирантура")]
			Postgraduation = 3
		}

		private static List<Degree> _degrees;

		public int ID;
		public string Name;

		public Degree(int id, string name)
		{
			ID = id;
			Name = name;
		}

		public static List<Degree> GetDegreesList()
		{
			if (_degrees == null)
			{
				_degrees = new List<Degree>();

				foreach (var value in Enum.GetValues(typeof(Degrees)))
				{
					_degrees.Add(new Degree((int) value, value.GetDescription()));
				}
			}

			return _degrees;
		}

		public static Degrees GetDegreeForGroupNamed(string groupName)
		{
			var degree = Degrees.Specialty;

			if (groupName.Length > 0)
			{
				char firstLetter = groupName[0];

				switch (firstLetter)
				{
					case 'м':
						degree = Model.Degree.Degrees.Magistracy;
						break;

					case 'б':
						degree = Model.Degree.Degrees.Bachelor;
						break;

					default:
						degree = Model.Degree.Degrees.Specialty;
						break;
				}
			}

			return degree;
		}
	}
}
