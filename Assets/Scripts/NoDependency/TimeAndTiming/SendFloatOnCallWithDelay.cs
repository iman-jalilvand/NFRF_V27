using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendFloatOnCallWithDelay : Base {
	public string CallSend;
	public string Outgoing;
	public float delay;

	private void Awake()
	{
		CacheMethod(CallSend, Send);
	}

	private void Send(object o)
	{
		float f;
		if(o is float) {
			f = (float) o;
			StartCoroutine(DelayRoutine(f));
		} else if(float.TryParse(o.ToString(), out f)) {
			StartCoroutine(DelayRoutine(f));
		}
	}

	private IEnumerator DelayRoutine(float f)
	{
		yield return new WaitForSeconds(delay);
		Call(Outgoing, cachedGameObject, f);
	}
}
