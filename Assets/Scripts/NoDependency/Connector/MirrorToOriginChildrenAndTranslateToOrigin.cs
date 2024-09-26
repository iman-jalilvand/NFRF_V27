using UnityEngine;
using System.Collections;

public class MirrorToOriginChildrenAndTranslateToOrigin : Base {

    public string Incoming;
    public string Outgoing;
    // Use this for initialization
    void Awake()
    {
        CacheMethod(Incoming, Mirror);
    }
	void Mirror(object o)
    {
        for(int i = 0,c = cachedOriginTransform.childCount; i < c; ++i)
        {
            Call(Incoming, cachedOriginTransform.GetChild(i).gameObject, o);
        }
        Call(Outgoing, cachedOriginGameObject, o);
    }
}
