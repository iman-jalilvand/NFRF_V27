using UnityEngine;
using System.Collections;

public class SetOriginLookDirectionOnCall : Base
{
    public string CallSetLookDirection;

    private Transform targetTransform;

    private void Awake()
    {
        CacheMethod(CallSetLookDirection, (o) =>
        {
            if (o is Vector3)
            {
                SetLookDirection((Vector3)o);
            }
            
        });
    }

    private void SetLookDirection(Vector3 forward)
    {
        cachedOriginTransform.rotation = Quaternion.LookRotation(forward);
    }
}
