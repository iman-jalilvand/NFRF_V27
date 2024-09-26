using UnityEngine;
using System.Collections;

public class EnableNamedChildrenOnCall : Base
{
	[UnityEngine.Serialization.FormerlySerializedAs("callEnabledNamedChildren")]
	public string CallEnabledNamedChildren;

	private void Awake()
	{
		CacheMethod(CallEnabledNamedChildren, EnableNamedChildren);
	}

	private void EnableNamedChildren(object o)
	{
		if (o != null) {
			Transform obj = cachedTransform.GetFirstDescendantWithName(o.ToString());
			// Transform obj = cachedTransform.Find(o.ToString());
			if (obj != null) {
				obj.gameObject.SetActive(true);
			} else {
				print(o + " not found");
			}
		}
	}
}
