using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendFloatOnDelayAfterDisable : Base {
	public string Outgoing;
	public float Value;
	public float Delay = 0f;

	protected override void OnDisable()
	{
		Invoke("Self", Delay);
		base.OnDisable();
	}

	private void Self()
	{
		Call(Outgoing, cachedGameObject, Value);
	}
}