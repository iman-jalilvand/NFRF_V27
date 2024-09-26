using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReplyFloatOnCall : Base {
    public string CallSend;
	public string CallSetParameter;
    public string Outgoing;
	public float Param;
    void Awake ()
	{
        CacheMethod(CallSend, Reply);
		CacheMethod(CallSetParameter, SetParameter);
	}

	private void SetParameter(object o)
	{
		float f;
		if(o is float) {
			Param = (float)o;
		} else if(float.TryParse(o.ToString(), out f)) {
			Param = f;
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
