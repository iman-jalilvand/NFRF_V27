using UnityEngine;
using System.Collections;

public class CallOnDisable : Base {
	public string Outgoing;

	protected override void OnDisable()
	{
		Invoke("Send", 0);
		base.OnDisable();
	}
	private void Send()
	{
		Call(Outgoing, cachedGameObject);
	}
}
