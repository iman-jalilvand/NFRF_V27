using UnityEngine;
using System.Collections;

public class DisableAllChildrenOnCall : Base {
	public string CallDisableAllChildren;

	private void Awake()
	{
		CacheMethod(CallDisableAllChildren, DisableAllChildren);
	}

    private void DisableAllChildren(object o)
    {
        foreach(Transform child in cachedTransform)
        {
			child.gameObject.SetActive(false);
		}
    }
}
