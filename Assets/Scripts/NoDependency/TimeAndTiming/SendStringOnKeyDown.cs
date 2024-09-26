using UnityEngine;
using System.Collections;

public class SendStringOnInput : Base {
	public KeyCode Key;
	public string Outgoing;
	public string Value;

	private void Update()
	{
		if(Input.GetKeyDown(Key)) {
			Call(Outgoing, cachedGameObject, Value);
		}
	}
}
