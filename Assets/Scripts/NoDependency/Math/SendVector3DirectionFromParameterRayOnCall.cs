using UnityEngine;
using System.Collections;

public class SendVector3DirectionFromParameterRayOnCall : Base
{
    public string Incoming;
    public string Outgoing;
    // Use this for initialization
    void Start()
    {
        CacheMethod(Incoming, OuputPoint);
    }

    void OuputPoint(object o)
    {
        if (o is Ray)
        {
            Call(Outgoing, cachedGameObject, ((Ray)o).direction);
        }
    }
}
