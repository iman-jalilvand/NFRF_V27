using UnityEngine;
using System.Collections;

public class RotateTargetWithParameterQuaternionOnCall : Base {

    public string Incoming;
    public string CallSetTarget;
    public Transform Target;

    void Awake()
    {
        CacheMethod(Incoming, Rotate);
        CacheMethod(CallSetTarget, SetTarget);
    }
    void Rotate(object o)
    {
        if (o is Quaternion)
        {
            if (Target)
            {
                Target.rotation *= (Quaternion)o;
            }
        }
    }
    void SetTarget(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Target = (Transform)o;
        }
    }
}
