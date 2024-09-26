using UnityEngine;
using System.Collections;

public class GameObjectInterface : Base {
	public GameObject target;
	public string CallReplace;

	private void Awake()
	{
		CacheMethod(CallReplace, Replace);
	}

	private void Replace(object o)
	{
		GameObject otherSource = o as GameObject;
		if(otherSource == null) {
			return;
		}

		GameObject newTarget = Instantiate(otherSource);
		if(newTarget == null) {
			return;
		}
		
		CopyTransform(target, newTarget);
		Destroy(target);
		target = newTarget;
	}
	
	private void CopyTransform(GameObject source, GameObject target) {
		CopyTransform(source.transform, target.transform);
	}

	private void CopyTransform(Transform source, Transform target) 
	{
		target.SetParent(source.parent);
		target.position = source.position;
		target.rotation = source.rotation;
		target.localScale = source.localScale;
	}
}
