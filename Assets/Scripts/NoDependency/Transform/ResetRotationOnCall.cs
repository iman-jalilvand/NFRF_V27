using UnityEngine;

public class ResetRotationOnCall : Base 
{
	[UnityEngine.Serialization.FormerlySerializedAs("callResetRotation")]
	public string CallResetRotation;
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Output;

    private void Awake()
	{
		CacheMethod(CallResetRotation, ResetRotation);
	}

	private void ResetRotation(object o)
	{
		cachedTransform.localRotation = Quaternion.identity;

		Call(Output, cachedGameObject);
	}
}
