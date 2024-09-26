using UnityEngine;
using System.Collections;

public class IfNull : Base {
	public string Incoming;
	public string OutgoingOnTrue;
	public string OutgoingOnFalse;
	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Call(o == null ? OutgoingOnTrue : OutgoingOnFalse, cachedGameObject, o);
		});
	}
}
