using UnityEngine;
using System.Collections;

public class SendTransformFromParameterOnCall : Base {

    public string Incoming;
	public string Outgoing;
	
    void Start ()
    {
        CacheMethod(Incoming, GameObjToTrans);
	}
    void GameObjToTrans(object o)
    {
        if(o is GameObject)
        {
            Call(Outgoing,cachedGameObject,((GameObject)o).transform);
        }
    }
}
