using UnityEngine;
using System.Collections;

public class StringPlayerPrefsInterface : Base {
	public string Key;

	public string CallSetKey;
	public string CallSetValue;
	public string CallGetValue;
	public string OutgoingGetValue;
	
	public string Value
	{
		get {
			return PlayerPrefs.GetString(Key);
		}

		set {
			PlayerPrefs.SetString(Key, value);
		}
	}

	private void Awake()
	{
		CacheMethod(CallSetKey, SetKey);
		CacheMethod(CallSetValue, SetValue);
		CacheMethod(CallGetValue, GetValue);
	}

	private void SetKey(object o)
	{
		Key = o.ToString();
	}

	private void SetValue(object o)
	{
		Value = o.ToString();
	}

	private void GetValue(object o)
	{
		Call(OutgoingGetValue, cachedGameObject, Value);
	}



}
