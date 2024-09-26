using UnityEngine;
using System.Collections;

public class SendGameObjectFromParameterRaycastHitOnCall : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
	}

	private void Send(object o)
	{
		if(o is RaycastHit) {
			RaycastHit hit = (RaycastHit) o;
			Call(Outgoing, cachedGameObject, hit.collider.gameObject);
		}
	}
}
