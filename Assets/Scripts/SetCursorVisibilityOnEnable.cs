using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorVisibilityOnEnable : MonoBehaviour
{
	public bool visible;
	private void OnEnable()
	{
		Cursor.visible = visible;
	}
}
