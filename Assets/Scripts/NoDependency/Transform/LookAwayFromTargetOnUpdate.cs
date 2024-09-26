using UnityEngine;
using System.Collections;

public class LookAwayFromTargetOnUpdate : Base {
	public Transform Target;
	
	void Update () {
		cachedTransform.rotation = Quaternion.LookRotation(cachedTransform.position - Target.position);
	}
}
