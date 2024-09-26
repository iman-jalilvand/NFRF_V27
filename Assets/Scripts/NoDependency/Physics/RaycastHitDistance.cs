using UnityEngine;
using System.Collections;

public class RaycastHitDistance : Base
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
        if (o is RaycastHit)
        {
            Call(Outgoing, cachedGameObject, ((RaycastHit)o).distance);
        }
    }
}
