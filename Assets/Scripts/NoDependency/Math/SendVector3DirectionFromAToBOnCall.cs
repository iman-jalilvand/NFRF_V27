using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendVector3DirectionFromAToBOnCall : Base {
	public Transform A, B;
	public string CallSetA;
	public string CallSetB;
	public string CallSendDirection;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(CallSetA, SetA);
		CacheMethod(CallSetB, SetB);
		CacheMethod(CallSendDirection, SendDirection);
	}

	private void SetA(object o)
	{
		if(o is GameObject)
		{
			o = ((GameObject)o).transform;
		}

		A = o as Transform;
	}

	private void SetB(object o)
	{
		if(o is GameObject)
		{
			o = ((GameObject)o).transform;
		}

		B = o as Transform;
	}

	private void SendDirection(object o)
	{
		if(A != null && B != null) {
			Vector3 A2B = B.position - A.position;
			Call(Outgoing, cachedGameObject, A2B);
		}
	}
}
