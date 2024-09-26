using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendGameObjectOnStart : Base {
	public string Outgoing;
	public GameObject Target;
	void Start () {
		Call(Outgoing, cachedGameObject, Target);
	}
}
