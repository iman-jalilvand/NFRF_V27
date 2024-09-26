using UnityEngine;
using System.Collections;

public class SetTargetTransformPositionAndRotationOnUpdate : MonoBehaviour {
	[UnityEngine.Serialization.FormerlySerializedAs("targetPosition")]
	public Vector3 TargetPosition;
	[UnityEngine.Serialization.FormerlySerializedAs("targetRotation")]
	public Quaternion TargetRotation;
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public Transform Target;
	[UnityEngine.Serialization.FormerlySerializedAs("lockRotation")]
	public bool LockRotation;
	[UnityEngine.Serialization.FormerlySerializedAs("lockPosition")]
	public bool LockPosition;
	[UnityEngine.Serialization.FormerlySerializedAs("local")]
	public bool Local;
	
	void Update () {
		if(LockPosition) {
			if(Local) {
				Target.localPosition = TargetPosition;
			} else {
				Target.position = TargetPosition;
			}
		}

		if(LockRotation) {
			if(Local) {
				Target.localRotation = TargetRotation;
			} else {
				Target.rotation = TargetRotation;
			}
		}
	}
}
