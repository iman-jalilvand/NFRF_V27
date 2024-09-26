using UnityEngine;
using System.Collections;

public class LimitedMirror : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;
    [UnityEngine.Serialization.FormerlySerializedAs("limit")]
	public int Limit = 1;

    private void Awake()
    {
        CacheMethod(Incoming, IncomingMethod);
    }

    private void IncomingMethod(object o)
    {
        for (int i = 0; i < Limit; ++i)
        {
            Call(Outgoing, cachedGameObject, o);
        }
    }
}
