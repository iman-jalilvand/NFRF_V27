using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListMirror : Base {
	public string Incoming;
    public string CallAddTarget;
    public string CallRemTarget;
    public List<GameObject> Targets;


    private void AddTarget(object o)
    {
        Targets.Add(o as GameObject);
    }
    private void RemoveTarget(object o)
    {
        Targets.Remove(o as GameObject);
    }

    private void Awake()
    {
        CacheMethod(CallAddTarget, AddTarget);
        CacheMethod(CallRemTarget, RemoveTarget);
        CacheMethod(Incoming, (o) =>
		{
			if(Targets == null) {
				return;
			}
            for (int i = 0, c = Targets.Count; i < c; ++i)
            {
                Call(Incoming, Targets[i], o);
            }
        });
	}
}
