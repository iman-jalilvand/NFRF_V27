using UnityEngine;
using System.Collections;

public class MirrorToOriginChildOnCall : Base {

    public string CallMirror;
    public string CallSetIndex;
    public int Index;

    void Awake()
    {
        CacheMethod(CallMirror, Mirror);
        CacheMethod(CallSetIndex, SetIndex);
    }

    void SetIndex(object o)
    {
        if(o is int)
        {
            Index = (int)o;
        }
    }

	void Mirror(object o)
    {
        if(Index < cachedOriginTransform.childCount)
        {
            Call(CallMirror, cachedOriginTransform.GetChild(Index).gameObject, o);
        }
    }
}
