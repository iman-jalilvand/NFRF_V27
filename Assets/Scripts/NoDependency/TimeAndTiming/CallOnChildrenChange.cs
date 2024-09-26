using UnityEngine;
using System.Collections;

public class CallOnChildrenChange : Base {
	public string Outgoing;
	private void OnTransformChildrenChanged()
	{
		Call(Outgoing, cachedGameObject);
	}
}
