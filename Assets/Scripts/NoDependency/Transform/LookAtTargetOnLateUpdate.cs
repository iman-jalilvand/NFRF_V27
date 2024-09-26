using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetOnLateUpdate : Base {
	public Transform Target;
	
	void LateUpdate () {
		cachedTransform.rotation = Quaternion.LookRotation(Target.position - cachedTransform.position, Target.up);
	}
}
