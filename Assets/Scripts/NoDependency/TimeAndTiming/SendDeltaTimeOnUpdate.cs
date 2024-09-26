using UnityEngine;
using System.Collections;

public class SendDeltaTimeOnUpdate : Base
{
	public string Outgoing;
	public bool Unscaled = false;
	void Update()
	{
		Call(Outgoing, cachedGameObject, (Unscaled ? Time.unscaledDeltaTime : Time.deltaTime));
	}
}
