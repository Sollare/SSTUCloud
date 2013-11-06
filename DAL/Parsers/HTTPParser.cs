﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
	public abstract class HTTPParser<T>
	{
		public abstract List<T> ParseEntitiesFromCode(string htmlCode);
	}
}
