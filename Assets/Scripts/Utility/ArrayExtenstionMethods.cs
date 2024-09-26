using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtenstionMethods
{
	public delegate bool Check<T>(T obj);
	public delegate float Test<T>(T obj);

	public static void SetActive(this GameObject[] array, bool value)
	{
		foreach (GameObject go in array)
		{
			go.SetActive(value);
		}
	}

	public static void Shuffle<T>(this T[] array)
	{
		for (int i = 0, max = array.Length; i < max; ++i)
		{
			int indexToSwapWith = UnityEngine.Random.Range(0, max);
			T item = array[i];
			array[i] = array[indexToSwapWith];
			array[indexToSwapWith] = item;
		}
	}

	public static void Shuffle<T>(this T[] from, T[] to)
	{
		System.Array.Copy(from, to, from.Length);
		to.Shuffle();
	}

	/// <summary>
	/// Returns an array containing random elements from array.
	/// Order is not guaranteed. 
	/// </summary>
	public static T[] Random<T>(this T[] array, int count)
	{
		T[] target;
		if (array.Length <= count)
		{
			target = new T[array.Length];
			System.Array.Copy(array, target, array.Length);
			return target;
		}

		List<T> list = new List<T>(array);
		target = new T[count];
		for (int i = 0; i < count; ++i)
		{
			T item = list.Random();
			target[i] = item;
			list.Remove(item);
		}

		return target;
	}


	public static T Random<T>(this T[] array)
	{
		return array[UnityEngine.Random.Range(0, array.Length)];
	}

	public static T Random<T>(this T[] array, T def)
	{
		if (array.Length == 0)
		{
			return def;
		}

		return array[UnityEngine.Random.Range(0, array.Length)];
	}

	public static T Random<T>(this T[] array, Check<T> condition)
	{
		return FindAll(array, condition).Random();
	}

	public static T Random<T>(this T[] array, Check<T> condition, T def)
	{
		return FindAll(array, condition).Random(def);
	}

	public static int FindIndex<T>(this T[] array, T item)
	{
		for (int i = 0, max = array.Length; i < max; ++i)
		{
			if (array[i] == null && item == null)
			{
				return i;
			}

			if (item != null && item.Equals(array[i]))
			{
				return i;
			}
			if (array[i] != null && array[i].Equals(item))
			{
				return i;
			}
		}

		return -1;
	}

	public static bool Has<T>(this T[] array, T item)
	{
		for (int i = 0, max = array.Length; i < max; ++i)
		{
			if (item.Equals(array[i]))
			{
				return true;
			}
		}

		return false;
	}

	public static T Find<T>(this T[] array, Check<T> check, T defaultValue)
	{
		for (int i = 0, max = array.Length; i < max; ++i)
		{
			T item = array[i];
			if (check(item))
			{
				return item;
			}
		}
		return defaultValue;
	}
	public static T Find<T>(this T[] array, Check<T> check)
	{
		for (int i = 0, max = array.Length; i < max; ++i)
		{
			T item = array[i];
			if (check(item))
			{
				return item;
			}
		}
		throw new KeyNotFoundException();
	}

	public static T[] FindAll<T>(this T[] array, Check<T> check)
	{
		List<T> list = new List<T>();
		for (int i = 0, max = array.Length; i < max; ++i)
		{
			T item = array[i];
			if (check(item))
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	public static T FindMin<T>(this T[] array, Test<T> test)
	{
		T min = array[0];
		float minVal = test(min);

		for (int i = 1, max = array.Length; i < max; ++i)
		{
			T item = array[i];
			float val = test(item);
			if (val < minVal)
			{
				min = item;
				minVal = val;
			}
		}

		return min;
	}

	public static bool ReplaceFirst<T>(this T[] array, T from, T to)
	{
		int i = array.FindIndex(from);
		if (i >= 0)
		{
			array[i] = to;
			return true;
		}
		else
		{
			return false;
		}
	}
}
