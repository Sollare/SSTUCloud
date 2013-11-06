using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Parsers
{
	class ClassroomsHTTPParser : HTTPParser<Classroom>
	{
		public override List<Classroom> ParseEntitiesFromCode(string htmlCode)
		{
			throw new NotImplementedException();
		}
	}
}
