using UnityEngine;
using System.Collections.Generic;

public class SortChildrenOnStart : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("method")]
	public SortMethod SortingMethodUsed;
	[UnityEngine.Serialization.FormerlySerializedAs("ascending")]
	public bool Ascending = true;

	private void Start()
	{
		Sort();
	}

	private void Sort()
	{
		switch(SortingMethodUsed) {
			case SortMethod.Lexicographical:
				Lexicographical();
			break;
		}
	}

	private void Lexicographical()
	{
		List<Transform> children = new List<Transform>();
		foreach(Transform child in cachedTransform) {
			children.Add(child);
		}

		children.Sort((a, b)=> {
			int result = a.name.CompareTo(b.name);
			if(Ascending) {
				return result;
			} else {
				return -result;
			}
		});

		for(int i = 0, max = children.Count; i < max; ++i) {
			children[i].SetSiblingIndex(i);
		}
	}



	public enum SortMethod
	{
		Lexicographical
	}
}
