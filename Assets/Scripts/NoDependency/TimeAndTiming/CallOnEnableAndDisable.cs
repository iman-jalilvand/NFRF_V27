using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallOnEnableAndDisable : Base
{
	public string OutgoingOnEnable;
	public string OutgoingOnDisable;

	public bool Broadcast = false;

	protected override void OnEnable()
	{
		base.OnEnable();
		if (Broadcast) {
			Call(OutgoingOnEnable, typeof(Base));
		} else {
			Call(OutgoingOnEnable, cachedGameObject);
		}
	}

	protected override void OnDisable()
	{
		if (Broadcast) {
			Call(OutgoingOnDisable, typeof(Base));
		} else {
			Call(OutgoingOnDisable, cachedGameObject);
		}
		base.OnDisable();
	}
}
