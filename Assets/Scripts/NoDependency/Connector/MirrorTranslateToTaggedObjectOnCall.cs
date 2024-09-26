using UnityEngine;
using System.Collections;

public class MirrorTranslateToTaggedObjectOnCall : Base {
	public string Tag;

	public string Incoming;
	public string Outgoing;

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
			Call(Outgoing, target, o);
		});
	}
}