using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class HashSetExtenstionMethods
{
	public static T Random<T>(this HashSet<T> set)
	{
		T picked = set.ElementAt(UnityEngine.Random.Range(0, set.Count));
		return picked;
	}

	public static T[] Random<T>(this HashSet<T> set, int count)
	{
		return set.ToArray().Random(count);
	}
}
