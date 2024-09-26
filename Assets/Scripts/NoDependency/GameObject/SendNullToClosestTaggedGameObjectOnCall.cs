using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendNullToClosestTaggedGameObjectOnCall : Base {
	public string Tag;
	public string Incoming;
	public string Outgoing;
	
	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			GameObject[] gos = GameObject.FindGameObjectsWithTag(Tag);
			if(gos.Length == 0) {
				return;
			}

			GameObject closest = gos[0];
			Vector3 currentPosition = cachedTransform.position;
			float closestDistance = Vector3.Distance(currentPosition, closest.transform.position);
			for(int i = 1, max = gos.Length; i < max; ++i) {
				GameObject go = gos[i];
				float distance = Vector3.Distance(currentPosition, go.transform.position);
				if(distance < closestDistance) {
					closestDistance = distance;
					closest = go;
				} 
			}

			Call(Outgoing, closest);
		});
	}
}
