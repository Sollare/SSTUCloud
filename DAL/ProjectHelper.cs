using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Collections;

public static class ProjectHelper
{

    //public static IEnumerable<Type> GetAllDerivedTypesOf(Type baseType)
    //{
    //    var types = Assembly.GetAssembly(baseType).GetTypes();
    //    return types.Where(t => t.IsSubclassOf(baseType));
    //}

    /// <summary>
    /// Возвращает все классы, которые наследуются от базового класса.
    /// </summary>
    /// <param name="baseType">Базовый класс.</param>
    public static IEnumerable<Type> GetAllDerivedTypesOf(Type baseType)
    {
        var types = Assembly.GetAssembly(baseType).GetTypes();

        return types.Where(baseType.IsAssignableFrom).Where(t => t != baseType);
    }


	public static string GetDescription<T>(this T value)
	{
		Type type = value.GetType();
		string name = Enum.GetName(type, value);
		if (name != null)
		{
			FieldInfo field = type.GetField(name);
			if (field != null)
			{
				DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
				if (attr == null)
				{
					return name;
				}
				else
				{
					return attr.Description;
				}
			}
		}
		return null;

	}


    /// <summary>
    /// Реализует ли объект данный интерфейс
    /// </summary>
    /// <typeparam name="T">Интерфейс</typeparam>
    /// <param name="comp"></param>
    /// <returns></returns>
    public static bool ImplementedBy<T>(this Component comp)
    {
        if (comp.GetType().GetInterfaces().Contains(typeof(T)))
        {
            return true;
        }
        return false;
    }
}
