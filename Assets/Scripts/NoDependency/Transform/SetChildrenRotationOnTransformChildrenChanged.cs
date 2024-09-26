using UnityEngine;

public class SetChildrenRotationOnTransformChildrenChanged : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("local")]
	public bool Local;
	[UnityEngine.Serialization.FormerlySerializedAs("forcedRotation")]
	public Quaternion ForcedRotation = Quaternion.identity;

	private void OnTransformChildrenChanged()
	{
		foreach(Transform child in cachedTransform) {
			if(Local) {
				child.localRotation = ForcedRotation;
			} else {
				child.rotation = ForcedRotation;
			}
		}
	}
}
