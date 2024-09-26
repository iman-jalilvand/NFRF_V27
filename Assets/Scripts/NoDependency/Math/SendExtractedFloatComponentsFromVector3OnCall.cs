using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendExtractedFloatComponentsFromVector3OnCall : Base
{
    public bool X;
    public bool Y;
    public bool Z;

    public string Incoming;
    public string OutgoingX;
    public string OutgoingY;
    public string OutgoingZ;


    void Start()
    {
        CacheMethod(Incoming, Extract);
    }

    void Extract(object o)
    {
        if (o is Vector3)
        {
            Extract((Vector3)o);
        }
        if (o is GameObject && (GameObject)o != null)
        {
            Extract(((GameObject)o).transform.position);
        }
        if (o is Transform && (Transform)o != null)
        {
            Extract(((Transform)o).position);
        }
    }

    private void Extract(Vector3 v)
    {
        if (X)
        {
            Call(OutgoingX, cachedGameObject, v.x);
        }
        if (Y)
        {
            Call(OutgoingY, cachedGameObject, v.y);
        }
        if (Z)
        {
            Call(OutgoingZ, cachedGameObject, v.z);
        }
    }
}
