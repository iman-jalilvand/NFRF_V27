using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : Base
{
	public Camera camera;
	public bool useMainIfNull = true;

	public Camera Camera
	{
		get
		{
			if (useMainIfNull && camera == null)
			{
				camera = Camera.main;
			}

			return camera;
		}
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 position = Camera.ScreenToWorldPoint(Input.mousePosition);
		position.z = 0;
		cachedTransform.position = position;
	}
}
