using UnityEngine;
using System.Collections.Generic;
using System;


public class GameObjectHashSetDictionary : Base
{
	public GameObject Target;
	public string ShareID;
	public TargetSetting TargetType;

	public string OutgoingOnAdded, OutgoingOnRemoved;
	public string OutgoingOnCallSend;
	public string CallSend;
	public string CallSetShareID;

	private static Dictionary<string, HashSet<GameObject>> classifiedObjects = new Dictionary<string, HashSet<GameObject>>();

	private delegate void ItemChanged(string shareID, GameObject item);

	// could have dictionary of event for optimization if needed.
	private static event ItemChanged OnAdd, OnRemove;

	public HashSet<GameObject> this[string key]
	{
		get
		{
			if (classifiedObjects.ContainsKey(key) == false)
			{
				classifiedObjects[key] = new HashSet<GameObject>();
			}

			return classifiedObjects[key];
		}
	}

	private void Awake()
	{
		OnAdd += OnClassifiedObjectAdded;
		OnRemove += OnClassifiedObjectRemoved;
		CacheMethod(CallSetShareID, SetShareID);
		CacheMethod(CallSend, SendGameObject);
		if (TargetType == TargetSetting.Source && Target != null)
		{
			Add(ShareID, Target);
		}
	}

	private void OnDestroy()
	{
		Remove(ShareID, Target);
	}


	private void OnClassifiedObjectAdded(string shareID, GameObject item)
	{
		if (TargetType == TargetSetting.Recipient && shareID == ShareID)
		{
			Call(OutgoingOnAdded, Target, item);
		}
	}

	private void OnClassifiedObjectRemoved(string shareID, GameObject item)
	{
		if (TargetType == TargetSetting.Recipient && shareID == ShareID)
		{
			Call(OutgoingOnRemoved, Target, item);
		}
	}

	private void Add(string shareID, GameObject item)
	{
        if (this[ShareID].Add(Target))
        {
            OnAdd(ShareID, item);
        }
	}

	private void Remove(string shareID, GameObject item)
	{
        if (this[ShareID].Remove(Target))
        {
            OnRemove(ShareID, item);
        }
	}

	private void SendGameObject(object o)
	{
		if (TargetType == TargetSetting.Recipient)
		{
			Call(OutgoingOnCallSend, Target, this[ShareID]);
		}
	}

	private void SetShareID(object o)
	{
		Remove(ShareID, Target);
		ShareID = o.ToString();
		Add(ShareID, Target);
	}

	public enum TargetSetting
	{
		Source,
		Recipient
	}
}

