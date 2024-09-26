using UnityEngine;
using System.Collections;

public class ChildMirror : Base {

    public string Incoming;
    public int Index;
	// Use this for initialization
	void Awake ()
    {
        CacheMethod(Incoming, Mirror);
	}
	void Mirror(object o)
    {
        if(Index < cachedTransform.childCount)
        {
            Call(Incoming, cachedTransform.GetChild(Index).gameObject, o);
        }
    }
}
