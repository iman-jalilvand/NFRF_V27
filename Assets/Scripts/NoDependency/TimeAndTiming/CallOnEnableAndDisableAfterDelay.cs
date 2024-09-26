using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallOnEnableAndDisableAfterDelay : Base {
	public string OutgoingOnEnable;
	public string OutgoingOnDisable;

	public float delay = 0;
	
	protected override void OnEnable()
	{
		base.OnEnable();
		Invoke("Enabled", delay);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		Invoke("Disabled", delay);
	}

	private void Enabled()
	{
		Call(OutgoingOnEnable, cachedGameObject);
	}

	private void Disabled()
	{
		Call(OutgoingOnDisable, cachedGameObject);
	}
}
