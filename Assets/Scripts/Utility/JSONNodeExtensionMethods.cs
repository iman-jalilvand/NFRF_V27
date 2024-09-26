using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JSONNodeExtensionMethods
{
	public static bool HasElementInArray(this JSONNode node, string arrayKey, string element)
	{
		foreach (var pair in node[arrayKey].AsArray)
		{
			if (element == pair.Value.Value)
			{
				return true;
			}
		}

		return false;
	}

	public static bool Has(this JSONNode node, string name)
	{
		foreach (var item in node.Keys)
		{
			if (item.Value.ToString() == name)
			{
				return true;
			}
		}

		return false;
	}
}
