using UnityEngine;
using System.Collections;
using System;

public class SendRayToTargetOnCall : Base
{
	public string CallSetSource;
	public string CallSetTarget;
	public string CallSend;
	public string Outgoing;

	public Transform Source;
	public Transform Target;

	private void Awake()
	{
		CacheMethod(CallSend, Send);
		CacheMethod(CallSetTarget, SetTarget);
		CacheMethod(CallSetSource, SetSource);
	}
	
	private void SetSource(object o)
	{
		Source = ExtractTransform(o);
	}

	private void Send(object o)
	{
		if(Target == null || Source == null) {
			return ;
		}

		Vector3 selfPosition = Source.position;
		Vector3 targetPosition = Target.position;
		Vector3 direction = (targetPosition - selfPosition);//.normalized; // no real reason to normalize here. 
		Ray ray = new Ray(selfPosition, direction);
		Call(Outgoing, cachedGameObject, ray);
	}
	
	private void SetTarget(object o)
	{
		Target = ExtractTransform(o);
	}
	
	private Transform ExtractTransform(object o)
	{
		if(o is GameObject && ((GameObject)o != null))
        {
			o = ((GameObject) o).transform;
		}
		return o as Transform;
	}
}
