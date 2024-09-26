using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReplyBoolOnCall : Base {
	public string Incoming;
	public string Outgoing;
	public string CallSetBool;
	public string CallSetTrue;
	public string CallSetFalse;

	public bool Param;

	private void Awake()
	{
		CacheMethod(Incoming, Reply);
		CacheMethod(CallSetBool, SetBool);
		CacheMethod(CallSetTrue, (o)=> {Param = true;});
		CacheMethod(CallSetFalse, (o)=> {Param = false;});
	}

	private void SetBool(object o)
	{
		bool b;

		if(o is bool) {
			Param = (bool)o;
		} else if(o != null && bool.TryParse(o.ToString(), out b)) {
			Param = b;
		}
	}
	
	private void Reply(object o)
	{
		KeyValuePair<Type, object> pair = CallStack.Peek();
		if(pair.Key.IsSubclassOf(typeof(Base)) || pair.Equals(typeof(Base))) {
			ReplyToBase((Base) pair.Value);
		} else if(pair.Key.IsSubclassOf(typeof(MonoBehaviour)) || pair.Equals(typeof(MonoBehaviour))) {
			ReplyToMonoBehaviour((MonoBehaviour) pair.Value);
		} else if(pair.Key.IsSubclassOf(typeof(MonoBehaviour)) || pair.Equals(typeof(MonoBehaviour))) {
			ReplyToGameObject((GameObject) pair.Value);
		}
	}

	private void ReplyToBase(Base b)
	{
		GameObject cgo = GetCachedGameObject(b);
		Call(Outgoing, cgo, Param);
	}

	private void ReplyToGameObject(GameObject go)
	{
		Call(Outgoing, go, Param);
	}

	private void ReplyToMonoBehaviour(MonoBehaviour mono)
	{
		Call(Outgoing, mono.gameObject, Param);
	}
}
