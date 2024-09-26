using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallOnMouseInput : Base
{
	public int MouseButton = 0;
	public string MouseDown;
	public string MouseUp;

	void Update()
	{
		if (Input.GetMouseButtonUp(MouseButton))
		{
			Call(MouseUp, cachedGameObject);
		}
		if (Input.GetMouseButtonDown(MouseButton))
		{
			Call(MouseDown, cachedGameObject);
		}
	}
}
