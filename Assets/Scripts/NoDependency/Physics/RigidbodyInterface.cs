using UnityEngine;
using System.Collections;

public class RigidbodyInterface : Base {
	public Rigidbody RBody;
	public string CallEnableKinematic;
	public string CallDisableKinematic;
	public string CallGetSpeed;

	public string OutgoingSpeed;

	private void Awake() 
	{
		CacheMethod(CallEnableKinematic, EnableKinematic);
		CacheMethod(CallDisableKinematic, DisableKinematic);
		CacheMethod(CallGetSpeed, GetSpeed);
	}

	private void GetSpeed(object o)
	{
		Call(OutgoingSpeed, cachedGameObject, RBody.velocity.magnitude);
	}

	private void EnableKinematic(object o)
	{
		RBody.isKinematic = true;
	}

	private void DisableKinematic(object o)
	{
		RBody.isKinematic = false;
	}
}
