using UnityEngine;
using System.Collections;

public class SendDeltaTimeOnLateUpdate : Base {
	public string Outgoing;
	void LateUpdate () {
		Call(Outgoing, cachedGameObject, Time.deltaTime);
	}
}
