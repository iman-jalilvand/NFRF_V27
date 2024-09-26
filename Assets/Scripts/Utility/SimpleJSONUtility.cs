using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SimpleJSONUtility
{
	public static bool HasKey(JSONNode node, string name)
	{
		foreach (var item in node.Keys)
		{
			if (item.ToString() == name)
			{
				return true;
			}
		}

		return false;
	}
	public static string GetValidKey(JSONNode node, params string[] names)
	{
		foreach (var item in node.Keys)
		{
			string name = item.Value;
			if (names.Contains(name))
			{
				return name;
			}
		}

		return null;
	}
	public static JSONNode GetValidNode(JSONNode node, params string[] names)
	{
		string key = GetValidKey(node, names);
		return node[key];
	}

	public static bool IsValueEqual(JSONNode node, string key, string value)
	{
		bool equal = node[key] == value;
		return equal;
	}

	public static bool HasElement(JSONArray array, string element)
	{
		foreach (var item in array)
		{
			string val = item.Value.Value.ToLower();
			element = element.ToLower();

			if (val == element)
			{
				return true;
			}
		}

		return false;
	}
}
