using UnityEngine;
using System.Collections;

public class SendRayFromTargetTransformWithLocalDirectionOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("target")]
	public Transform Target;
    [UnityEngine.Serialization.FormerlySerializedAs("direction")]
	public Vector3 Direction;
    [UnityEngine.Serialization.FormerlySerializedAs("setTargetKey")]
	public string CallSetTarget;
    [UnityEngine.Serialization.FormerlySerializedAs("setDirectionKey")]
	public string CallSetDirection;
    [UnityEngine.Serialization.FormerlySerializedAs("incomingKey")]
	public string CallSendRay;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoingKey")]
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

        Vector3 worldDirection = Target.TransformDirection(Direction);

        Ray ray = new Ray(Target.position, worldDirection);
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
