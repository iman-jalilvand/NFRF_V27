using UnityEngine;
using System.Collections;

public class InstantiateParameterGameObjectAsChildOnCall : Base {

    [UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	// Use this for initialization
	void Awake () {
        CacheMethod(Incoming,Instantiate);
	}
	
    void Instantiate(object o)
    {
		if(o is Transform)
		{
			o = ((Transform)o).gameObject;
		}

        if(o is GameObject)
        {
            Instantiate((GameObject)o,cachedTransform,false);
        }
    }
}
