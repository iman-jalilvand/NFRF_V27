using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtenstionMethods
{
	public delegate bool Check<T>(T element);
	public static void Shuffle<T>(this List<T> array)
	{
		for (int i = 0, max = array.Count; i < max; ++i)
		{
			int indexToSwapWith = UnityEngine.Random.Range(0, max);
			T item = array[i];
			array[i] = array[indexToSwapWith];
			array[indexToSwapWith] = item;
		}
	}

	public static T At<T>(this List<T> array, int index)
	{
		if (array.Count <= index)
		{
			return default(T);
		}

		return array[index];
	}

	public static T Random<T>(this List<T> array)
	{
		return array[UnityEngine.Random.Range(0, array.Count)];
	}
}
