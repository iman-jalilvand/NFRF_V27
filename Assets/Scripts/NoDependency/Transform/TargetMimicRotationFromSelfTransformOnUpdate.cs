using UnityEngine;

[ExecuteInEditMode]
public class TargetMimicRotationFromSelfTransformOnUpdate : Base
{
    public string CallSetTarget;
	public Transform Target;

	public bool X = true;
	public bool Y = true;
	public bool Z = true;

    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(CallSetTarget, SetTarget);
    }
    void SetTarget(object o)
    {
        if (o is Transform)
        {
            Target = (Transform)o;
        }
    }
    void Update()
    {
        if (Target)
        {
            Vector3 curRot = Target.rotation.eulerAngles; 
            Vector3 tarRot = cachedTransform.rotation.eulerAngles;
            if (X)
            {
                curRot.x = tarRot.x;
            }
            if (Y)
            {
                curRot.y = tarRot.y;
            }
            if (Z)
            {
                curRot.z = tarRot.z;
            }
            cachedTransform.rotation = Quaternion.Euler(curRot);
        }
    }
}
