using UnityEngine;
using System.Collections;

public class CallOnParentChanged : Base 
{
	public string Outgoing;

	private void OnTransformParentChanged()
	{
		Call(Outgoing, cachedGameObject);
	}
}
