using UnityEngine;
using System.Collections;

public class RotateOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("callRotateByIncrementLeft")]
	public string CallRotateByIncrementLeft;
	[UnityEngine.Serialization.FormerlySerializedAs("callRotateByIncrementRight")]
	public string CallRotateByIncrementRight;
	[UnityEngine.Serialization.FormerlySerializedAs("callRotateBy90")]
	public string CallRotateBy90;
	[UnityEngine.Serialization.FormerlySerializedAs("callRotateBy180")]
	public string callRotateBy180;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoingRotationSet")]
	public string OutgoingRotationSet;
    [UnityEngine.Serialization.FormerlySerializedAs("rotationIncrement")]
	public float RotationIncrement;

    [UnityEngine.Serialization.FormerlySerializedAs("rotationAxis")]
	public Behaviour RotationAxis;

    private void Awake()
    {
        CacheMethod(CallRotateByIncrementLeft, (o) =>
        {
            HandleRotation(-RotationIncrement);
        });

        CacheMethod(CallRotateByIncrementRight, (o) =>
        {
            HandleRotation(RotationIncrement);
        });

        CacheMethod(CallRotateBy90, (o) =>
        {
            HandleRotation(90f);
        });

        CacheMethod(callRotateBy180, (o) =>
        {
            HandleRotation(180f);
        });
    }

    private void HandleRotation(float RotationIncrement)
    {
        float axisToRotate = 0f;

        switch (RotationAxis)
        {
            case Behaviour.xAxis:
                axisToRotate = cachedTransform.rotation.x;
                axisToRotate += RotationIncrement;
                cachedTransform.rotation = Quaternion.Euler(cachedTransform.rotation.eulerAngles.x + RotationIncrement, cachedTransform.rotation.eulerAngles.y, cachedTransform.rotation.eulerAngles.z);
                break;
            case Behaviour.yAxis:
                axisToRotate = cachedTransform.rotation.y;
                axisToRotate += RotationIncrement;
                cachedTransform.rotation = Quaternion.Euler(cachedTransform.rotation.eulerAngles.x, cachedTransform.rotation.eulerAngles.y + RotationIncrement, cachedTransform.rotation.eulerAngles.z);
                break;
            case Behaviour.zAxis:
                axisToRotate = cachedTransform.rotation.z;
                axisToRotate += RotationIncrement;
                cachedTransform.rotation = Quaternion.Euler(cachedTransform.rotation.eulerAngles.x, cachedTransform.rotation.eulerAngles.y, cachedTransform.rotation.eulerAngles.z + RotationIncrement);
                break;
            default:
                break;
        }

        Call(OutgoingRotationSet, cachedGameObject);
    }

    public enum Behaviour
    {
        xAxis,
        yAxis,
        zAxis,
    }
}
