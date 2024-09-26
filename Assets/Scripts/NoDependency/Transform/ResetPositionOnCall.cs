using UnityEngine;
using System.Collections;

public class ResetPositionOnCall : Base {
	public string CallReset;

	private void Awake()
	{
		CacheMethod(CallReset, Reset);
	}

	private void Reset(object o)
	{
		cachedTransform.localPosition = Vector3.zero;
	}
}
