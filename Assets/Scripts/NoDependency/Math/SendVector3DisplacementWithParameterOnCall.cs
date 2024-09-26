using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendVector3DisplacementWithParameterOnCall : Base {

    public string CallSendDisplacement, OutgoingDisplacement;
    public string CallSetTarget;
    public DisplacementDirectionEnum DisplacementDirection;
    public Vector3 Target;

    public enum DisplacementDirectionEnum
    {
        ToParameter,
        ToTarget
    }

    void Awake()
    {
        CacheMethod(CallSetTarget, SetTarget);
        CacheMethod(CallSendDisplacement, SendDisplacement);
    }
    void SetTarget(object o)
    {
        if(o is Vector3)
        {
            Target = (Vector3)o;
        }
    }
    void SendDisplacement(object o)
    {
        if( o is Vector3)
        {
            Vector3 Displacement;
            if(DisplacementDirection == DisplacementDirectionEnum.ToParameter)
            {
                Displacement = (Vector3)o - Target;
            }
            else
            {
                Displacement = Target - (Vector3)o;
            }
            Call(OutgoingDisplacement, cachedGameObject, Displacement);
        }
    }
}
