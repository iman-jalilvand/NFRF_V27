using UnityEngine;
using System.Collections;

public class SendIntChildCountOnTransformChildrenChanged : Base {
	public string CallOnChildCountChange;
	private void OnTransformChildrenChanged()
	{
		if(cachedTransform == null) {
			return;
		}
		Call(CallOnChildCountChange, cachedGameObject, cachedTransform.childCount);
	}
}
