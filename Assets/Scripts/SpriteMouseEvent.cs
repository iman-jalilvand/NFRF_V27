using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMouseEvent : Base
{
	public string OnMouseEnter;
	public string OnMouseExit;

	public SpriteRenderer target;
	public Camera main;
	private Camera Main
	{
		get
		{
			if (main == null)
			{
				main = Camera.main;
			}

			return main;
		}
	}

	private bool mouseHovering = false;

	private void Update()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = -0.5f;
		mousePosition = Main.ScreenToWorldPoint(mousePosition);
		Bounds bounds = target.bounds;
		bool mouseInSprite = bounds.IntersectRay(new Ray(mousePosition, Vector3.forward));
		// bool mouseInSprite = bounds.Contains(mousePosition);
		if (mouseHovering != mouseInSprite)
		{
			mouseHovering = mouseInSprite;
			Call(mouseHovering ? OnMouseEnter : OnMouseExit, cachedGameObject);
		}
	}
}
