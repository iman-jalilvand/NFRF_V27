using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendVector3SelfPositionOnCollision : Base {
	public string Outgoing;
	
	public bool DestroyAfter = true;
	public LayerMask layerToIgnore;


	private void OnCollisionEnter(Collision c)
	{
		if(IsInLayerMask(c.gameObject.layer, layerToIgnore)) {
			return;
		}

		// alternative that could do similar job with this script is to use contact.
		Call(Outgoing, cachedGameObject, cachedTransform.position);
		if(DestroyAfter) {
			Destroy(cachedGameObject);
		}
	}

	private void SendSelfPosition(object o)
	{
		Call(Outgoing, cachedGameObject, cachedTransform.position);
	}

	public static bool IsInLayerMask(int layer, LayerMask layermask)
	{
		return layermask == (layermask | (1 << layer));
	}
}
