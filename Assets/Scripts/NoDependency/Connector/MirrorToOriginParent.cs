using UnityEngine;
using System.Collections;

public class MirrorToOriginParent : Base
{
    public string Incoming;

    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(Incoming, (o) =>
        {
            if (moduleLevel != 1)
            {
                Call(Incoming, cachedOriginTransform.parent.gameObject, o);
            }
            else
            {
                throw new System.Exception("Mirroring To Origin Parent Module Level cannot be 1");
            }
        });
    }
}
