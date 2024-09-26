using UnityEngine;
using System.Collections;

public class SendDisplacementOnCall : Base
{

    public string Incoming;
    public string Outgoing;
    void Start()
    {
        CacheMethod(Incoming, InvTransf);
    }
    void InvTransf(object o)
    {
        if (o is Vector3)
        {
            Call(Outgoing,cachedGameObject,((Vector3)o) - cachedTransform.position);
        }
    }

}
