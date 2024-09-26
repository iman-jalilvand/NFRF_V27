using UnityEngine;
using System.Collections;

public class SendVector3ParameterTransformedToDesiredSpaceOfTransformTargetOnCall : Base
{
	[UnityEngine.Serialization.FormerlySerializedAs("Incoming")]
    public string CallSend;
	public string Outgoing, CallSetTarget, CallSetSpace;
    public Transform Target;
    public Space DesiredSpace;
    void Awake()
    {
        CacheMethod(CallSend, SendInvTransform);
        CacheMethod(CallSetTarget, SetTarget);
        CacheMethod(CallSetSpace, SetSpace);
    }
    void SendInvTransform(object o)
    {
        if (Target && o is Vector3)
        {
            Vector3 direction = (Vector3)o;
            if (DesiredSpace == Space.Self)
            {
                Call(Outgoing,cachedGameObject, Target.InverseTransformDirection(direction));
            }
            else
            {
                Call(Outgoing,cachedGameObject,Target.TransformDirection(direction));
            }
        }
    }
    void SetSpace(object o)
    {
        if (o is Space)
        {
            DesiredSpace = (Space)o;
        }
    }
    void SetTarget(object o)
    {
        if (o is GameObject)
        {
            Target = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Target = (Transform)o;
        }
    }
}
