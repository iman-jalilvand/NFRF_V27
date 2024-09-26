using UnityEngine;
using System.Collections;

public class SendVector3SelfLocalSpacePositionFromParameterWorldSpaceVector3PositionOnCall : Base
{

    public string Incoming;
	public string Outgoing;
	
    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(Incoming, Multiply);
    }
	
    void Multiply(object o)
    {
        if (o is Vector3)
        {
            Call(Outgoing, cachedGameObject, cachedTransform.TransformPoint((Vector3)o));
        }
    }
}
