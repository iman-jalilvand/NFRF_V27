using UnityEngine;
using System.Collections;

public class MirrorToChildrenAndTranslateToSelf : Base {

    public string Incoming;
    public string SelfOutgoing;
    // Use this for initialization
    void Awake()
    {
        CacheMethod(Incoming, Mirror);
    }
	void Mirror(object o)
    {
        for(int i = 0,c = cachedTransform.childCount; i < c; ++i)
        {
            Call(Incoming, cachedTransform.GetChild(i).gameObject, o);
        }
        Call(SelfOutgoing, cachedGameObject, o);
    }
}
