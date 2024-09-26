using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetParentOnCall : Base
{
	[UnityEngine.Serialization.FormerlySerializedAs("callResetParent")]
	public string CallResetParent;

	void Awake()
	{
		CacheMethod(CallResetParent, ResetParent);
	}

	private void ResetParent(object o)
	{
		cachedTransform.parent = null;
	}
}
