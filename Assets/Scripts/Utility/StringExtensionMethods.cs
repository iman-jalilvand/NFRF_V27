using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensionMethods
{
	public static string[] SplitLines(this string content, System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries)
	{
		return content.Split(new char[] { '\n' }, option);
	}
}
