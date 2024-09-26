using UnityEngine;
using System.Collections.Generic;

public class EnabledGameObjectHashSetStorage : Base {
	public string CallAdd;
	public string CallRemove;
	public string CallGetElements;
	public string CallGetElement;

    public string CallCheckElement;
    public string OutgoingElementFound;
    public string OutgoingElementNotFound;

    public string OutgoingElements;
	public string OutgoingElement;
    public string OutgoingOnElementAdded;
    public string OutgoingOnElementRemoved;
    public string OutgoingOnCountChanged;

	private HashSet<GameObject> set = new HashSet<GameObject>();
	public HashSet<GameObject> Set
	{
		get {
			Sanitize();
			return set;
		}
	}

	private void Awake()
	{
		CacheMethod(CallAdd, Add);
		CacheMethod(CallRemove, Remove);
		CacheMethod(CallGetElement, GetElement);
        CacheMethod(CallGetElements, GetElements);
        CacheMethod(CallCheckElement, CheckElement);
    }
    private void CheckElement(object o)
    {
        bool v = false;
        GameObject outgoing = null;
        if(o is GameObject)
        {
            outgoing = (GameObject)o;
            v = set.Contains(outgoing);
            Call(v ? OutgoingElementFound : OutgoingElementNotFound, cachedGameObject, outgoing);
        }
        if (o is Transform)
        {
            outgoing = ((Transform)o).gameObject;
            v = set.Contains(outgoing);
            Call(v ? OutgoingElementFound : OutgoingElementNotFound, cachedGameObject, outgoing);
        }
    }
	private void Add(object o)
	{
		GameObject param = ExtractGameObject(o);
		if(param != null && Set.Add(param)) {
			Call(OutgoingOnElementAdded, cachedGameObject, param);
            SendCount();
        }
    }

	private void Remove(object o)
	{
		GameObject param = ExtractGameObject(o);
		if(param != null)
        {
            Call(OutgoingOnElementRemoved, cachedGameObject, param);
            Set.Remove(param);
            SendCount();
        }
    }

	private void GetElements(object o)
	{
		Call(OutgoingElements, cachedGameObject, Set);
	}

	private void GetElement(object o)
	{
		foreach(GameObject go in Set) {
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
            int setCount = Set.Count;
            Call(OutgoingOnCountChanged, cachedGameObject, setCount);
        }
    }

	private void Sanitize()
	{
		set.RemoveWhere((o)=> {
			return o == null || o.activeInHierarchy == false;
		});
	}
}
