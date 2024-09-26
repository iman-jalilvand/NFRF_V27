using UnityEngine;
using System.Collections;

public class SendChildrenTransformFromParameterOnCall : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Extract);
	}

	private void Extract(object o)
	{
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}

		Transform parameter = o as Transform;
		if(parameter == null) {
			return;
		}
		int max = parameter.childCount;
		Transform[] extracted = new Transform[max];
		for(int i = 0; i < max; ++i) {
			extracted[i] = parameter.GetChild(i);
		}

		Call(Outgoing, cachedGameObject, extracted);
	}
}
