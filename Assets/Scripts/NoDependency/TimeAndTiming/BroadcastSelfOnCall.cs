using UnityEngine;
using System.Collections;

public class BroadcastSelfOnCall : Base
{
	public string Incoming;
	public string Outgoing;

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
            Call(Outgoing, typeof(Base), cachedGameObject);
        });
    }
}
