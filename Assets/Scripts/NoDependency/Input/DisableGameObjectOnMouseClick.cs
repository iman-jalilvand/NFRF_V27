using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObjectOnMouseClick : Base
{
	public int MouseButton;
	public GameObject Target;

	private void Update()
	{
		if (Input.GetMouseButton(MouseButton)) {
			if (Target == null) {
				cachedGameObject.SetActive(false);
			} else {
				Target.SetActive(false);
			}
		}
	}
}
