using UnityEngine;
using System.Collections;

public class SendTargetDeltaPositionOnCall : Base {

    public string CallSendDelta;
    public string OutgoingDelta;
    public string CallSendPreviousPosition;
    public string OutgoingPreviousPosition;
    public string CallSetTarget;
    public Transform Target;
    Vector3 position;
    Vector3 prevPosition;
	
    void Awake()
    {
        CacheMethod(CallSetTarget, SetTarget);
        CacheMethod(CallSendDelta, SendDelta);
        CacheMethod(CallSendPreviousPosition, SendPrevPosition);
    }
    void SetTarget(object o)
    {
		if (o is GameObject)
        {
			Target = ((GameObject)o).transform;
            prevPosition = position = Target.position;
        }
    }
    // Update is called once per frame
    void SendPrevPosition(object o)
    {
        Call(OutgoingPreviousPosition, cachedGameObject, prevPosition);
    }
    // Update is called once per frame
    void SendDelta (object o)
    {
		if (Target == null)
			return;
        position = Target.position;
        Vector3 displacement = position - prevPosition;
        Call(OutgoingDelta, cachedGameObject,displacement);
        prevPosition = Target.position;
	}
}
