using UnityEngine;
using System.Collections;

public class SendVector3TargetDirectionOnCall : Base {
	public Direction ChosenDirection;
	public string Incoming;
	public string Outgoing;
    public string CallSetTarget;

    public Transform Target;

    private void Awake()
    {
        CacheMethod(Incoming, SendDirection);
        CacheMethod(CallSetTarget, SetTarget);
    }

	private void SendDirection(object o)
	{
		Vector3 dir = GetDirection(Target.transform, ChosenDirection);
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

    private void SetTarget(object o)
    {
        if (o is GameObject)
        {
            Target = ((GameObject)o).transform;
        }
        else if (o is Transform)
        {
            Target = (Transform)o;
        }
        else if (o is Component)
        {
            Target = ((Component)o).transform;
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
