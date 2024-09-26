using UnityEngine;
using System.Collections;

public class EnableRandomChildOnCall : Base {
	public string CallEnableRandomChild;

	private void Awake()
	{
		CacheMethod(CallEnableRandomChild, EnableRandomChild);
	}

	private void EnableRandomChild(object o)
	{
		int i = UnityEngine.Random.Range(0, cachedTransform.childCount);
		Transform child = cachedTransform.GetChild(i);
		child.gameObject.SetActive(true);
	}
}
