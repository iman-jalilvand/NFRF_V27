using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class MimicTransformOnUpdate : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("target")]
	public Transform Target;
    [UnityEngine.Serialization.FormerlySerializedAs("dontMimicRotation")]
	public bool DontMimicRotation = false;
    [UnityEngine.Serialization.FormerlySerializedAs("dontMimicPosition")]
	public bool DontMimicPosition = false;
    [UnityEngine.Serialization.FormerlySerializedAs("capMovement")]
	public bool CapMovement = false;
    [UnityEngine.Serialization.FormerlySerializedAs("movementLimit")]
	public float MovementLimit = 0.1f;
	
    void Update()
    {
        if (Target)
        {
            if (CapMovement)
            {
                cachedTransform.position = Vector3.MoveTowards(cachedTransform.position, Target.position, MovementLimit);
            }
            else if(!DontMimicPosition)
            {
                cachedTransform.position = Target.position;
            }
            if (!DontMimicRotation)
            {
                cachedTransform.rotation = Target.rotation;
            }
            cachedTransform.localScale = ConvertLossyScaleToLocalScale(Target.lossyScale);
        }
    }

    private Vector3 ConvertLossyScaleToLocalScale(Vector3 lossyScale)
    {
        if(cachedTransform.parent == null)
        {
            return lossyScale;
        }
        Vector3 parentScales = cachedTransform.parent.lossyScale;
        Vector3 localScale = new Vector3(lossyScale.x / parentScales.x, lossyScale.y / parentScales.y, lossyScale.z / parentScales.z);
        return localScale;
    }
}
