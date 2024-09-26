using UnityEngine;
using System.Collections;

public class RaycastHitToGameobject : Base {

    public string Incoming;
    public string Outgoing;
	void Start()
    {
        CacheMethod(Incoming, OuputPoint);
    }
    void OuputPoint(object o)
    {
        if(o is RaycastHit)
        {
            Call(Outgoing,cachedGameObject,((RaycastHit)o).collider.gameObject);
        }
    }
}
