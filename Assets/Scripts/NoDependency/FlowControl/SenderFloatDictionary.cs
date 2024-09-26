using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SenderFloatDictionary : Base {
	public string CallRegister;
	public string CallGetMax;
	public string OutgoingMaxFloat;
	public string OutgoingMaxSender;

	private Dictionary<GameObject, float> records = new Dictionary<GameObject, float>();

	private void Awake()
	{
		CacheMethod(CallRegister, Register);
		CacheMethod(CallGetMax, GetMax);
	}

	private void Register(object o)
	{
		KeyValuePair<Type, object> senderPair = CallStack.Peek();
		GameObject sender = ExtractGameObject(senderPair.Value);
		float f;
		if(sender != null && o is float) {
			records[sender] = (float)o;
		} else if(sender != null && float.TryParse(o.ToString(), out f)) {
			records[sender] = f;
		}
	}

	private void GetMax(object o)
	{
		float max = float.MinValue;
		GameObject sender = null;

		foreach(KeyValuePair<GameObject, float> record in records) {
			if(record.Value > max) {
				sender = record.Key;
				max = record.Value;
			}
		}

		Call(OutgoingMaxFloat, cachedGameObject, max);
		Call(OutgoingMaxSender, cachedGameObject, sender);
	}

	private GameObject ExtractGameObject(object o)
	{
		GameObject result = null;
		if(o is MonoBehaviour) {
			o = ((MonoBehaviour)o).gameObject;
		}

		if(o is GameObject) {
			result = o as GameObject;
		}

		return result;
	}
}
