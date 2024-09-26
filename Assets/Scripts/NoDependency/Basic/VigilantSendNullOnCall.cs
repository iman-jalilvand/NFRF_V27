using UnityEngine;
using System.Collections;

public class VigilantSendNullOnCall : Base {
	public string CallSend;
	public string Outgoing;

	private void Awake()
	{
		base.OnEnable();

		CacheMethod(CallSend, Send);
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}

	protected override void OnEnable()
	{
		//
	}

	protected override void OnDisable()
	{
		//
	}

	private void Send(object o)
	{
		Call(Outgoing, cachedGameObject);
	}
}
