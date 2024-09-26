using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MimicPositionAndRotationOnUpdate  : Base
{
    public string SetTarget;
	public Transform Target;
	
    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(SetTarget, SetTar);
    }

	private void Update()
	{
		Call();
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
    void Call()
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
