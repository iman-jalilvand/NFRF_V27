using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VigilantGameObjectHashSetStorage : Base {
	public string CallAdd;
	public string CallRemove;
	public string CallGetElements;
	public string CallGetElement;

	public string OutgoingElements;
	public string OutgoingElement;
	public string OutgoingOnElementAdded;
    public string OutgoingOnCountChanged;

	private HashSet<GameObject> set = new HashSet<GameObject>();

	private void Awake()
	{
		base.OnEnable();
		CacheMethod(CallAdd, Add);
		CacheMethod(CallRemove, Remove);
		CacheMethod(CallGetElement, GetElement);
		CacheMethod(CallGetElements, GetElements);
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}

	protected override void OnDisable()
	{
		//
	}

	protected override void OnEnable()
	{
		//
	}

	private void Add(object o)
	{
		GameObject param = ExtractGameObject(o);
		if(param != null && set.Add(param)) {
			Call(OutgoingOnElementAdded, cachedGameObject, param);
            SendCount();
        }
    }

	private void Remove(object o)
	{
		GameObject param = ExtractGameObject(o);
		if(param != null) {
			set.Remove(param);
            SendCount();
        }
    }

	private void GetElements(object o)
	{
		Call(OutgoingElements, cachedGameObject, set);
	}

	private void GetElement(object o)
	{
		foreach(GameObject go in set) {
			Call(OutgoingElement, cachedGameObject, go);
		}
	}
	
	private GameObject ExtractGameObject(object o)
	{
		if(o is Transform) {
			o = ((Transform)o).gameObject;
		}
		return o as GameObject;
	}

    private void SendCount()
    {
        if (!string.IsNullOrEmpty(OutgoingOnCountChanged))
        {
            int setCount = set.Count;
            Call(OutgoingOnCountChanged, cachedGameObject, setCount);
        }
    }
}
