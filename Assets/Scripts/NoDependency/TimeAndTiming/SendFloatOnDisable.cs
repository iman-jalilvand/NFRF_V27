using UnityEngine;
using System.Collections;

public class SendFloatOnDisable : Base {
	public string Outgoing;
	public float Value;
	protected override void OnDisable()
	{
		Call(Outgoing, cachedGameObject, Value);
		base.OnDisable();
	}
}
