using UnityEngine;
using System.Collections;

public class SendFloatDistanceFromSelfWithOffsetToParameterVector3PositionOnCall : Base {

    public string Incoming, Outgoing;

	public Vector3 Offset;

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
            Call(Outgoing,cachedGameObject,Vector3.Distance(cachedTransform.position + Offset, (Vector3)o));
        }
    }
}
