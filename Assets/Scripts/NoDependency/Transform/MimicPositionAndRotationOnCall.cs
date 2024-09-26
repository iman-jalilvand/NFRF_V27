using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicPositionAndRotationOnCall : Base
{
    public string Incoming;
    public string SetTarget;
	public Transform Target;
	
    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(SetTarget, SetTar);
        CacheMethod(Incoming, Call);
    }

    void SetTar(object o)
    {
        if(o is GameObject)
        {

            Target = ((GameObject)o).transform;
        }
        else if(o is Transform)
        {
            Target = (Transform)o;
        }
    }
    void Call(object o)
    {
        if (Target)
        {
            cachedTransform.position = Target.position;
        }
        if (Target)
        {
            cachedTransform.rotation = Target.rotation;
        }
	}
}
