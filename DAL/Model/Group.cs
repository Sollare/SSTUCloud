using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Model;

namespace DAL
{
	public class Group
	{
		public int ID;
		public string Name;
		public int DID;
		public int TFID;

		private Degree.Degrees _degree;
		[JsonFx.Json.JsonIgnoreAttribute]
		public Degree.Degrees Degree {
			get { return _degree; }
			private set { _degree = value;
				DID = (int) value;
			}
		}

		private TeachingForm.TeachingForms _teachingForm;
		[JsonFx.Json.JsonIgnoreAttribute]
		public TeachingForm.TeachingForms TeachingForm
		{
			get { return _teachingForm; }
			private set
			{
				_teachingForm = value;
				TFID = (int)value;
			}
		}

		public Group(int id, string name, Degree.Degrees degree, TeachingForm.TeachingForms form)
		{
			ID = id;
			Name = name.Trim();
			Degree = degree;
			TeachingForm = form;
		}
	}
}
