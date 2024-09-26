using UnityEngine;
using System.Collections;

public class SendFloatDotProductWithTwoVector3sOnCall : Base
{

	public Vector3 LHS;
	public Vector3 RHS;
	public string Incoming;
	public string Outgoing;
	public string CallSetLeftHandSide;
	public string CallSetRightHandSide;

	void Awake()
	{
		CacheMethod(Incoming, Dot);
		CacheMethod(CallSetLeftHandSide, SetLeft);
		CacheMethod(CallSetRightHandSide, SetRight);
	}

	void Dot(object o)
	{
		Call(Outgoing, cachedGameObject, Vector3.Dot(LHS, RHS));
	}

	void SetLeft(object o)
	{
		if (o is Vector3)
		{
			LHS = (Vector3)o;
		}
	}

	void SetRight(object o)
	{
		if (o is Vector3)
		{
			RHS = (Vector3)o;
		}
	}
}
