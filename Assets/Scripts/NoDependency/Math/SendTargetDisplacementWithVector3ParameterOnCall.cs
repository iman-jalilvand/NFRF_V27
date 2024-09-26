using UnityEngine;
using System.Collections;

public class SendTargetDisplacementWithVector3ParameterOnCall : Base
{
    public Transform Target;
    public string CallGetDisplacement;
    public string Outgoing;
    public string CallSetTarget;
    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(CallGetDisplacement, Displacement);
        CacheMethod(CallSetTarget, SetTarget);
    }
    void SetTarget(object o)
    {
        if (o is GameObject)
        {
            Target = ((GameObject)o).transform;
        }
        else if (o is Transform)
        {
            Target = (Transform)o;
        }
        else if (o is Component)
        {
            Target = ((Component)o).transform;
        }
    }
    void Displacement(object o)
    {
        if (o is Vector3)
        {
            Call(Outgoing,cachedGameObject,((Vector3)o) - Target.position);
        }
    }

}
