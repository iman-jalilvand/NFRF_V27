using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastOriginPositionOnCall : Base
{
	public string Incoming;
	public string Outgoing;

	protected void Start()
	{
		CacheMethod(Incoming, Send);
	}

	private void Send(object o)
	{
		Call(Outgoing, typeof(Base), transform.position);
	}
}
