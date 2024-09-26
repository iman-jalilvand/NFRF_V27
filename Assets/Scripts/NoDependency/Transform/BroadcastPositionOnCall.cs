using UnityEngine;
using System.Collections;

public class BroadcastPositionOnCall : Base
{
	public string Incoming;
	public string Outgoing;

    protected void Start()
    {
        CacheMethod(Incoming, Send);
    }

    private void Send(object o)
    {
        Call(Outgoing, typeof(Base),cachedTransform.position);
    }
}
