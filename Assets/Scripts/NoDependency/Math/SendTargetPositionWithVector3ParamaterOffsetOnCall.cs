using UnityEngine;
using System.Collections;

public class SendTargetPositionWithVector3ParamaterOffsetOnCall : Base {
    public string Incoming, Outgoing;
    public string CallSetTarget;
    public Transform Target;
	void Awake () {
        CacheMethod(Incoming, SendOffsetPosition);
        CacheMethod(CallSetTarget, SetTarget);

    }
    void SetTarget(object o)
    {
        if (o is GameObject)
        {
            Target = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Target = ((Transform)o);
        }
    }
    void SendOffsetPosition(object o)
    {
        if (Target)
        {
            if (o is Vector3)
            {
                Call(Outgoing, cachedGameObject, Target.position + (Vector3)o);
            }
        }
    }
}
