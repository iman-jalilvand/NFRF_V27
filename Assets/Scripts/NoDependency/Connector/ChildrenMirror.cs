using UnityEngine;
using System.Collections;

public class ChildrenMirror : Base {

    public string Incoming;
    // Use this for initialization
    void Awake()
    {
        CacheMethod(Incoming, Mirror);
    }
	void Mirror(object o)
    {
        for (int i = 0, c = cachedTransform.childCount; i < c ; ++i)
        {
            Call(Incoming, cachedOriginTransform.GetChild(i).gameObject, o);
        }
    }
}
