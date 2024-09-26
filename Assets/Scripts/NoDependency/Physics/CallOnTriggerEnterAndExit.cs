using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallOnTriggerEnterAndExit : Base {
	public string OutgoingOnEnter;
	public string OutgoingOnExit;

	public Target EnterTarget;
	public Target ExitTarget;

	private void OnTriggerEnter(Collider c)
	{
		switch(EnterTarget) {
			case Target.Other:
				Call(OutgoingOnEnter, c.gameObject);
				break;
			case Target.Self:
				Call(OutgoingOnEnter, cachedGameObject);
				break;
		}
	}

	private void OnTriggerExit(Collider c)
	{
		switch(ExitTarget) {
			case Target.Other:
				Call(OutgoingOnExit, c.gameObject);
				break;
			case Target.Self:
				Call(OutgoingOnExit, cachedGameObject);
				break;
		}
	}

	public enum Target 
	{
		Self,
		Other
	}
}
