using UnityEngine;
using System.Collections;

public class RotateAroundPointOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("callSetTarget")]
	public string CallSetTarget;
	[UnityEngine.Serialization.FormerlySerializedAs("callRotateByIncrementLeft")]
	public string CallRotateByIncrementLeft;
	[UnityEngine.Serialization.FormerlySerializedAs("callRotateByIncrementRight")]
	public string CallRotateByIncrementRight;
	[UnityEngine.Serialization.FormerlySerializedAs("callRotateBy90Degrees")]
	public string CallRotateBy90Degrees;
	[UnityEngine.Serialization.FormerlySerializedAs("callRotateBy180Degrees")]
	public string CallRotateBy180Degrees;

    private Transform targetTransform;

    private void Awake()
    {
        CacheMethod(CallSetTarget, (o) =>
        {
            if (o is GameObject)
            {
                o = ((GameObject)o).transform;
            }

            if (o is Transform)
            {
                SetTarget((Transform)o);
            }
        });

        CacheMethod(CallRotateByIncrementLeft, (o) =>
        {
            cachedTransform.RotateAround(targetTransform.position, Vector3.up, -10);
        });

        CacheMethod(CallRotateByIncrementRight, (o) =>
        {
            cachedTransform.RotateAround(targetTransform.position, Vector3.up, 10);
        });

        CacheMethod(CallRotateBy90Degrees, (o) =>
        {
            cachedTransform.RotateAround(targetTransform.position, Vector3.up, 90);
        });

        CacheMethod(CallRotateBy180Degrees, (o) =>
        {
            cachedTransform.RotateAround(targetTransform.position, Vector3.up, 180);
        });
    }

    private void SetTarget(Transform newTarget)
    {
        targetTransform = newTarget;
    }
}
