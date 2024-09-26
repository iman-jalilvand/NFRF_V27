using UnityEngine;
using System.Collections;

public class MoveParentToOnCall : Base {

    public string Incoming;
	
	void Start ()
    {
		CacheMethod(Incoming, Move);
		//Call(Incoming, cachedGameObject);
	}
    void Move(object o)
    {
        if(o is Vector3)
        {
            cachedTransform.parent.position = (Vector3)o;
        }
    }
}
