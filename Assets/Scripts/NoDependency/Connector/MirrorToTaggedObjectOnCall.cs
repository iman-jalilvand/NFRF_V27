using UnityEngine;
using System.Collections;

public class MirrorToTaggedObjectOnCall : Base {
	public string Tag;

	public string Incoming;

	private GameObject Target {
		get {
			return GameObject.FindGameObjectWithTag(Tag);
		}
	}

	private void Awake()
	{
		CacheMethod(Incoming, (o) =>
		{
			GameObject target = Target;
			if(target == null) {
				return;
			}
			Call(Incoming, target, o);
		});
	}
}