using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithVector3ParameterOnCall : Base {
	public string Incoming;

	private void Awake()
	{
		CacheMethod(Incoming, Move);
	}

	private void Move(object o)
	{
		Vector3 parameter = (Vector3) o;
		cachedTransform.position += parameter;
	}
}
