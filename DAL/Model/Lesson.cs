using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Model
{
	class Lesson
	{
		public int ID;
		public int Name;
		public int Number;

		public int ClassroomID;
		public int TeacherID;
		public int[] GroupsID;
	}
}
