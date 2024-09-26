using UnityEngine;
using System.Collections;

public class SendPositionFromParameterOnCall : Base
{

    public string Incoming;
	public string Outgoing;
    // Use this for initialization
    void Start()
    {
        CacheMethod(Incoming, TransToPosition);
    }
    void TransToPosition(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Call(Outgoing, cachedGameObject, ((Transform)o).position);
        }
    }
}
