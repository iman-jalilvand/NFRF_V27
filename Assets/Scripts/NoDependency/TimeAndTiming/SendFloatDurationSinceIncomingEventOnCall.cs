using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendFloatDurationSinceIncomingEventOnCall : Base {
	public string CallIncomingEvent;
	public string CallGetDuration;
	public string Outgoing;
	public bool CountFromStart = true;
	private float? EventTimeStamp;


	private void Awake()
	{
		CacheMethod(CallIncomingEvent, IncomingEvent);
		CacheMethod(CallGetDuration, GetDuration);
		EventTimeStamp = Time.realtimeSinceStartup;
	}

	private void IncomingEvent(object o)
	{
		EventTimeStamp = Time.realtimeSinceStartup;
	}

	private void GetDuration(object o)
	{
		if(EventTimeStamp != null) {
			Call(Outgoing, cachedGameObject, Time.realtimeSinceStartup - EventTimeStamp);
		}
	}
	
}
