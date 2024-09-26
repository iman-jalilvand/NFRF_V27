using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensionMethods
{
	public delegate bool TransformCheck(Transform t);
	public delegate void TransformAction(Transform t);

	public static List<Transform> GetGeneration(this Transform trans, int generation)
	{
		if (generation < 0)
		{
			throw new UnityException("Not Implemented. GetGeneration(int generation) generation must be zero or positive. ");
		}

		List<Transform> items = new List<Transform>();
		if (generation == 0)
		{
			items.Add(trans);
			return items;
		}

		foreach (Transform child in trans)
		{
			items.AddRange(child.GetGeneration(generation - 1));
		}

		return items;
	}

	public static bool CheckGeneration(this Transform trans, int generation, TransformCheck check)
	{
		List<Transform> items = trans.GetGeneration(generation);
		foreach (Transform item in items)
		{
			bool c = check(item);

			if (!c)
			{
				return false;
			}
		}

		return true;
	}

	public static void SetText(this Transform trans, string text)
	{
		UnityEngine.UI.Text t = trans.GetComponentInChildren<UnityEngine.UI.Text>();
		if (t != null)
		{
			t.text = text;
		}

		TextMesh tm = trans.GetComponentInChildren<TextMesh>();
		if (tm != null)
		{
			tm.text = text;
		}
	}

	public static void ReplaceText(this Transform trans, string from, string to)
	{
		UnityEngine.UI.Text t = trans.GetComponentInChildren<UnityEngine.UI.Text>();
		if (t != null)
		{
			t.text = t.text.Replace(from, to);
		}

		TextMesh tm = trans.GetComponentInChildren<TextMesh>();
		if (tm != null)
		{
			tm.text = t.text.Replace(from, to);
		}
	}

	public static void ForEachChildren(this Transform trans, TransformAction action)
	{
		foreach (Transform child in trans)
		{
			action(child);
		}
	}

	public static void DestroyAllChildren(this Transform trans)
	{
		List<Transform> children = new List<Transform>();
		foreach (Transform child in trans)
		{
			children.Add(child);
		}

		for (int i = 0, max = children.Count; i < max; ++i)
		{
			GameObject.Destroy(children[i].gameObject);
		}
	}

	public static void ForEachDescendants(this Transform trans, TransformAction action)
	{
		foreach (Transform child in trans)
		{
			action(child);
			child.ForEachDescendants(action);
		}
	}

	public static HashSet<Transform> GetDescendants(this Transform trans, TransformCheck check)
	{
		HashSet<Transform> descendants = new HashSet<Transform>();
		foreach (Transform child in trans)
		{
			if (check(child))
			{
				descendants.Add(child);
			}

			descendants.UnionWith(GetDescendants(child, check));
		}

		return descendants;
	}

	public static Transform GetFirstDescendant(this Transform trans, TransformCheck check)
	{
		foreach (Transform child in trans)
		{
			if (check(child))
			{
				return child;
			}

			Transform candidate = GetFirstDescendant(child, check);
			if (candidate != null)
			{
				return candidate;
			}
		}

		return null;
	}

	public static Transform GetFirstDescendantWithName(this Transform trans, string name)
	{
		return trans.GetFirstDescendant((t) =>
		{
			return t.name.Equals(name);
		});
	}

	public static Transform GetFirstSibling(this Transform trans, TransformCheck check)
	{
		foreach (Transform sibling in trans.parent)
		{
			if (sibling == trans)
			{
				continue;
			}
			if (check(sibling))
			{
				return sibling;
			}
		}
		return null;
	}

	public static Transform FindAncestor(this Transform trans, TransformCheck check)
	{
		if (trans.parent == null)
		{
			return null;
		}

		if (check(trans.parent))
		{
			return trans.parent;
		}

		return FindAncestor(trans.parent, check);
	}
}
