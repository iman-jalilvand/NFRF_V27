using UnityEngine;
using System.Collections.Generic;
using System;

public class ReplyDistanceBetweenOnCall : Base {
	public string CallCalculate;
	public string CallSetSourceA;
	public string CallSetSourceB;
	public string Outgoing;

	public Transform SourceA;
	public Transform SourceB;
	

	private void Awake()
	{
		CacheMethod(CallCalculate, Calculate);
		CacheMethod(CallSetSourceA, SetSourceA);
		CacheMethod(CallSetSourceB, SetSourceB);
	}

	private void Calculate(object o)
	{
		if(SourceA == null || SourceB == null) {
			return ;
		}

		float distance = Vector3.Distance(SourceA.position, SourceB.position);
		Reply(distance);
	}

	private void SetSourceA(object o)
	{
		SourceA = CastToTransform(o);
	}

	private void SetSourceB(object o)
	{
		SourceB = CastToTransform(o);
	}

	private Transform CastToTransform(object o)
	{
		Transform trans = null;
		if(o is GameObject) {
			trans = ((GameObject)o).transform;
		}

		if(o is Transform) {
			trans = (Transform) o;
		}
		
		return trans;
	}
	
	private void Reply(float distance)
	{
		KeyValuePair<Type, object> pair = CallStack.Peek();
		if(pair.Key.IsSubclassOf(typeof(Base)) || pair.Equals(typeof(Base))) {
			ReplyToBase((Base) pair.Value, distance);
		} else if(pair.Key.IsSubclassOf(typeof(MonoBehaviour)) || pair.Equals(typeof(MonoBehaviour))) {
			ReplyToMonoBehaviour((MonoBehaviour) pair.Value, distance);
		} else if(pair.Key.IsSubclassOf(typeof(MonoBehaviour)) || pair.Equals(typeof(MonoBehaviour))) {
			ReplyToGameObject((GameObject) pair.Value, distance);
		}
	}

	private void ReplyToBase(Base b, float distance)
	{
		GameObject cgo = GetCachedGameObject(b);
		Call(Outgoing, cgo, distance);
	}

	private void ReplyToGameObject(GameObject go, float distance)
	{
		Call(Outgoing, go, distance);
	}

	private void ReplyToMonoBehaviour(MonoBehaviour mono, float distance)
	{
		Call(Outgoing, mono.gameObject, distance);
	}
}