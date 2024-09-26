using UnityEngine;
using System.Collections;

public class SelfMirror : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("msg")]
	public string Incoming;
    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(Incoming, (o) =>
        {
            Call(Incoming, cachedOriginGameObject, o);
        });
    }
}
