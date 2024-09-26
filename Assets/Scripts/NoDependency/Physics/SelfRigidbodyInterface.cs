using UnityEngine;

public class SelfRigidbodyInterface: Base {
	[UnityEngine.Serialization.FormerlySerializedAs("rb")]
	private Rigidbody RBody;
	public string CallEnableKinematic;
	public string CallDisableKinematic;
	public string CallAddForce;

	private void Awake() 
	{
		UpdateCachedFields();
		RBody = cachedGameObject.GetComponent<Rigidbody>();
		CacheMethod(CallEnableKinematic, EnableKinematic);
		CacheMethod(CallDisableKinematic, DisableKinematic);
		CacheMethod(CallAddForce, AddForce);
	}

	private void EnableKinematic(object o)
	{
		RBody.isKinematic = true;
	}

	private void DisableKinematic(object o)
	{
		RBody.isKinematic = false;
	}

	private void AddForce(object o)
	{
		if(!(o is Vector3)) {
			return;
		}

		Vector3 force = (Vector3) o;
		RBody.AddRelativeForce(force);
	}
}
