using UnityEngine;
using System.Collections;

public class SendFloatDistanceFromSelfToParameterVector3PositionOnCall : Base {

    public string Incoming, Outgoing;
	void Awake () {
        CacheMethod(Incoming, GetDistance);
	}
	void GetDistance(object o)
    {
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}

		if(o is Transform) {
			o = ((Transform)o).position;
		}


        if(o is Vector3)
        {
            Call(Outgoing,cachedGameObject,Vector3.Distance(cachedTransform.position, (Vector3)o));
        }
    }
}
