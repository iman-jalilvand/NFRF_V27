using UnityEngine;
using System.Collections;

public class RigidbodyMirror : Base {
	public string Incoming;
	private Rigidbody rb;
	public Rigidbody Target {
		get {
			if(rb == null) {
				rb = GetComponentInParent<Rigidbody>();
			}

			return rb;
		}
	}

	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Rigidbody body = Target;
			if(body == null) {
				return;
			}

			Call(Incoming, body.gameObject, o);
		});
	}
}
