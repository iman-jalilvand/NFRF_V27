using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TargetMimicPositionFromSelfTransformOnUpdate : Base
{
    public string SetTarget;
	public Transform Target;
    
    public bool X = true;
	public bool Y = true;
	public bool Z = true;
	
    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(SetTarget, SetTar);
    }
    void SetTar(object o)
    {
        if(o is Transform)
        {
            Target = (Transform)o;
        }
    }
    void Update()
    {
        if (Target)
        {
            Vector3 curPos = Target.position;
            Vector3 tarPos = cachedTransform.position;
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
