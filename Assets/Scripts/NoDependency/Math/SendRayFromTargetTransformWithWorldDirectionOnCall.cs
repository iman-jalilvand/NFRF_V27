using UnityEngine;
using System.Collections;

public class SendRayFromTargetTransformWithWorldDirectionOnCall : Base
{
	public Transform Target;
	public Vector3 Direction;
	public string CallSetTarget;
	public string CallSetDirection;
	public string CallSendRay;
	public string Outgoing;
	
    void Awake()
    {
        CacheMethod(CallSendRay, SendRay);
        CacheMethod(CallSetTarget, SetTarget);
        CacheMethod(CallSetDirection, SetDirection);
    }
    void SendRay(object o)
    {
		if(Target == null) {
			return;
		}


        Ray ray = new Ray(Target.position, Direction);
        Call(Outgoing,cachedGameObject ,ray);
    }
    void SetTarget(object o)
    {
        if(o is GameObject)
        {
            o = ((GameObject)o).transform;
        }
        if(o is Transform)
        {
            Target = (Transform)o;
        }
    }
    void SetDirection(object o)
    {
        if (o is Vector3)
        {
            Direction = (Vector3)o;
        }
        else if(o is Quaternion)
        {
            Direction = ((Quaternion)o).eulerAngles;
        }
    }
}
