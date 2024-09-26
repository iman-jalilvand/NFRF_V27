using UnityEngine;
using System.Collections;

public class SetChildrenPositionOnTransformChildrenChanged : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("local")]
	public bool Local;
	[UnityEngine.Serialization.FormerlySerializedAs("forcedPosition")]
	public Vector3 ForcedPosition;

	private void OnTransformChildrenChanged()
	{
		foreach(Transform child in cachedTransform) {
			if(Local) {
				child.localPosition = ForcedPosition;
			} else {
				child.position = ForcedPosition;
			}
		}
	}
}
