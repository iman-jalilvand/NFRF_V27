using UnityEngine;
using System.Collections;

public class MirrorTranslatorSelf : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(Incoming, MirrorMethod);
    }

    private void MirrorMethod(object o)
    {
        Call(Outgoing, cachedGameObject, o);
    }
}
