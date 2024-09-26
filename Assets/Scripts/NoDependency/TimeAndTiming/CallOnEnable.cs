using UnityEngine;
using System.Collections;

public class CallOnEnable : Base {
	public string Outgoing;

	protected override void OnEnable()
	{
		base.OnEnable();
		Invoke("Send", 0);
	}

	private void Send()
	{
		Call(Outgoing, cachedGameObject);
	}
}
