using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicPositionOnLateUpdate : Base
{
    public string SetTarget;
	public Transform Target;
    
    public bool X = true;
	public bool  Y = true;
	public bool Z = true;
	
    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(SetTarget, SetTar);
    }

	private void LateUpdate()
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
            Vector3 curPos = cachedTransform.position;
            Vector3 tarPos = Target.position;
			if(X && Y && Z)
			{
				cachedTransform.position = Target.position;
				return;
			}
            if (X)
            {
                curPos.x = tarPos.x;
            }
            if (Y)
            {
                curPos.y = tarPos.y;
            }
            if (Z)
            {
                curPos.z = tarPos.z;
            }
            cachedTransform.position = curPos;
        }
    }
}
