using UnityEngine;
using System.Collections;

public class SetLookDirectionOnCall : Base
{
    public string Incoming;

    private Transform targetTransform;

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
            if (o is Vector3)
            {
                SetLookDirection((Vector3)o);
            }
            
        });
    }

    private void SetLookDirection(Vector3 forward)
    {
        cachedTransform.rotation = Quaternion.LookRotation(forward);
    }
}
