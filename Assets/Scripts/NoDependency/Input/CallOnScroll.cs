using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallOnScroll : Base
{
	public float Threshold;
	public string OutgoingOnScrollUp;
	public string OutgoingOnScrollDown;
	private void Update()
	{
		float wheel = Input.GetAxis("Mouse ScrollWheel");
		if (wheel > Threshold) {
			Call(OutgoingOnScrollUp, cachedGameObject);
		}
		if (wheel < -Threshold) {
			Call(OutgoingOnScrollDown, cachedGameObject);
		}
	}
}
