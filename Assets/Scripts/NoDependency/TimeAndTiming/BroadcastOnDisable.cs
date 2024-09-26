using UnityEngine;
using System.Collections;

public class BroadcastOnDisable  : Base {
	public string Outgoing;

	protected override void OnDisable()
	{
		base.OnEnable();
		Invoke("Send", 0);
	}

	private void Send()
	{
		Call(Outgoing, typeof(Base));
	}
}
