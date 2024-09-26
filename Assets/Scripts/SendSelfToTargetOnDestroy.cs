using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendSelfToTargetOnDestroy : Base
{
	public string Message;
	public GameObject Target;

	private void OnDestroy()
	{
		Call(Message, Target, cachedGameObject);
	}
}
