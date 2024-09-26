using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastSelfOnStart : Base {
	public string Outgoing;
	void Start () {
		Call(Outgoing, typeof(Base), cachedGameObject);
	}
}
