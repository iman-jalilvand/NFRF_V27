using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetOnUpdate : Base {
	public Transform Target;
	
	void Update () {
		cachedTransform.rotation = Quaternion.LookRotation(Target.position - cachedTransform.position);
	}
}
