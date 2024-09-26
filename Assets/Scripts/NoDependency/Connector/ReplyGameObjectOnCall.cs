using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReplyGameObjectOnCall : Base {
	public string CallReply;
	public string CallSetParam;
	public string Outgoing;
	public GameObject Param;

	private void Awake()
	{
		CacheMethod(CallReply, Reply);
		CacheMethod(CallSetParam, SetParam);
	}
	
	private void SetParam(object o)
	{
		Param = ExtractGameObject(o);
	}

	private GameObject ExtractGameObject(object o)
	{
		GameObject go = null;
		if(o is Transform) {
			go = ((Transform)o).gameObject;
		}

		if(o is GameObject) {
			go = (GameObject)o;
		}

		return go;
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