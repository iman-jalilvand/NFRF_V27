using UnityEngine;
using System.Collections;

public class LerpColor : Base
{
	[ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
	public Color A;
	[ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
	public Color B;
	public float LerpValue;

	public Color Lerped
	{
		get
		{
			return Color.Lerp(A, B, LerpValue);
		}
	}

	// Make this if needed
	public string callSetLerpValue;

	// public string SetColorA
	// public string SetColorB; 

	public string Incoming;

	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Out);
		CacheMethod(callSetLerpValue, SetLerpValue);
	}

	private void SetLerpValue(object o)
	{
		if (!(o is float)) {
			return;
		}

		LerpValue = (float)o;
	}

	private void Out(object o)
	{
		Call(Outgoing, cachedGameObject, Lerped);
	}
}
