using UnityEngine;
using System.Collections;

public class SendVector3NormalizedFromParameterVector3OnCall : Base
{
    public string Incomining;
    public string OutGoing;
    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(Incomining, Normalize);
    }
    void Normalize(object o)
    {
        if (o is Vector3)
        {
            Call(OutGoing, cachedGameObject, Vector3.Normalize((Vector3)o));
        }
    }
}