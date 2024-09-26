using UnityEngine;
using System.Collections;

public class MirrorFromOriginToSelf : Base
{
    public string Incoming;

    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(Incoming, (o) =>
        {
			GameObject From = cachedOriginGameObject;
			GameObject To = cachedGameObject;

			if (From == To)
			{
				Incoming = "SELF MIRRORRING";
				Debug.LogError("SpyFromRootToSelfMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(Incoming, To, o);
			}
        }, cachedOriginGameObject);
    }
}
