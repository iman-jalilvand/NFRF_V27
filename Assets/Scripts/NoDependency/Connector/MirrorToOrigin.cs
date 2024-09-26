using UnityEngine;
using System.Collections;

public class MirrorToOrigin : Base
{
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
