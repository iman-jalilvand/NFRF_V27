using UnityEngine;
using System.Collections;

public class SetSphereColliderRadiusWithParameterOnCall : Base {

    public string CallSetRadius, CallSetTarget;
    public SphereCollider Target;

    void Awake()
    {
        CacheMethod(CallSetRadius, SetRadius);
    }
    void SetTarget(object o)
    {
        if(o is SphereCollider)
        {
            Target = (SphereCollider)o;
        }
    }
    void SetRadius(object o)
    {
        if(Target && o is float)
        {
            Target.radius = (float)o;
        }
    }
}
