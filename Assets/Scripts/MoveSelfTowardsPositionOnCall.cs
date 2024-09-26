using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelfTowardsPositionOnCall : Base
{
	public Vector3 Position;
	public float Speed;

	public string CallMove;

	private void Awake()
	{
		CacheMethod(CallMove, Move);
	}

	private void Move(object o)
	{
		StartCoroutine(MoveRoutine());
	}

	private IEnumerator MoveRoutine()
	{
		while (CachedTransform.position != Position)
		{
			CachedTransform.position = Vector3.MoveTowards(CachedTransform.position, Position, Speed * Time.deltaTime);
			yield return null;
		}
	}
}
