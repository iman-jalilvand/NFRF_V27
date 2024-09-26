using UnityEngine;
using System.Collections;

public class SendVector3ParameterDirectionOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("direction")]
	public Direction ChosenDirection;
	[UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, SendDirection);
	}

	private void SendDirection(object o)
	{
		GameObject other = o as GameObject;
		if(other == null) {
			return;
		}

		Vector3 dir = GetDirection(other.transform, ChosenDirection);
		Call(Outgoing, cachedGameObject, dir);
	}

	private Vector3 GetDirection(Transform trans, Direction dir)
	{
		switch(dir)
		{
			case Direction.Backward:
				return -trans.forward;
			case Direction.Down:
				return -trans.up;
			case Direction.Forward:
				return trans.forward;
			case Direction.Left:
				return -trans.right;
			case Direction.Right:
				return trans.right;
			case Direction.Up:
				return trans.up;
			default:
				return Vector3.zero;
		}
	}

	public enum Direction
	{
		Up,
		Down,
		Left,
		Right,
		Forward,
		Backward
	}
}
