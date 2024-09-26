using UnityEngine;
using System.Collections;

public class LookAtTaggedObjectOnUpdate : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("tag")]
	public string Tag;

	private void Update () {
		GameObject target = GameObject.FindGameObjectWithTag(Tag);
		if(target != null) {
			cachedTransform.LookAt(target.transform);
		}
	}
}
