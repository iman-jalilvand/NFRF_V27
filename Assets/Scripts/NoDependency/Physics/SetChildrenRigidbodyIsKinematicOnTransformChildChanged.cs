using UnityEngine;
using System.Collections;

public class SetChildrenRigidbodyIsKinematicOnTransformChildChanged : Base {
	public bool Value = true;
	private void OnTransformChildrenChanged()
	{
		foreach(Transform child in cachedTransform) {
			Rigidbody rb = child.GetComponent<Rigidbody>();
			if(rb != null) {
				rb.isKinematic = Value;
			}
		}
	}
}
