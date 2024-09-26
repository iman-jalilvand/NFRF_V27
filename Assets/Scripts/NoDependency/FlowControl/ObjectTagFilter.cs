using UnityEngine;
using System.Collections;

public class ObjectTagFilter : Base {
	public string Tag;
	public string Incoming;
	// if you want other for those not qualify in list, just use one more. 
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Filter);
	}

	private void Filter(object o)
	{
		GameObject other = o as GameObject;
		if(other == null) {
			return;
		}

		if(other.tag != Tag) {
			// you are NOT included in layermask. 
			return ;
		}
		// you are included in layermask. 
		Call(Outgoing, cachedGameObject, o);

	}
}
