using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetPositionOnCall : Base
{
	public Transform Target;
	public bool Local;
	public string Incoming;

	public Vector3 Position;

	private void Awake()
	{
		CacheMethod(Incoming, (o) =>
		{
			if (Local)
			{
				Target.localPosition = Position;
			}
			else
			{
				Target.position = Position;
			}
		});
	}
}
