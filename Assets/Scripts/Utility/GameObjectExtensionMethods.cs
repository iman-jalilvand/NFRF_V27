using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensionMethods
{
	public static Vector3 GetPosition(this GameObject go)
	{
		return go.transform.position;
	}

	public static Quaternion GetRotation(this GameObject go)
	{
		return go.transform.rotation;
	}
}
