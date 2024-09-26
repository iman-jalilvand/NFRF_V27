using UnityEngine;
using System.Collections;

public class MirrorFromOriginToParent : Base
{
    public string Incoming;

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
			GameObject From = cachedOriginGameObject;
			GameObject To = cachedTransform.parent.gameObject;

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
