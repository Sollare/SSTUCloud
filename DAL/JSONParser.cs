using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonFx.Json;

namespace DAL
{
	public class JSONParser
	{
		private static JSONParser _instance;

		public static JSONParser Instance
		{
			get
			{
				if(_instance == null)
					_instance = new JSONParser();

				return _instance;
			}
		}

		protected JSONParser()
		{
		}

		public T Deserialize<T>(string str)
		{
			return JsonReader.Deserialize<T>(str);
		}

		public string Serialize(object value)
		{
			return JsonWriter.Serialize(value);
		}
	}
}
