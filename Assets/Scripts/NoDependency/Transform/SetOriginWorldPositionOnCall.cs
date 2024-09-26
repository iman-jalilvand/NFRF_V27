using UnityEngine;
using System.Collections;

public class SetOriginWorldPositionOnCall : Base
{
	public string CallSetPosition;

    private void Awake()
    {
        CacheMethod(CallSetPosition, (o) =>
        {
            if (o is Vector3)
            {
                SetPosition((Vector3)o);
            }
        });
    }
    private void SetPosition(Vector3 targetPosition)
    {
        cachedOriginTransform.position = targetPosition;
    }
}
