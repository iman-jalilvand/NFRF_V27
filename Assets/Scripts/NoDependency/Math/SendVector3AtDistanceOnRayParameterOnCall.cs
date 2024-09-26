using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendVector3AtDistanceOnRayParameterOnCall : Base
{
    public string CallSendVector, OutgoingVector;
    public string CallSetDistance;
    public float Distance;

    public void Awake()
    {
        CacheMethod(CallSetDistance, SetDistance);
        CacheMethod(CallSendVector, SendVector);
    }
    private void SendVector(object o)
    {
        if (o is Ray)
        {
            Ray ray = (Ray)o;
            Call(OutgoingVector, cachedGameObject, ray.GetPoint(Distance));
        }
    }
    private void SetDistance(object o)
    {
        float f;
        if (o is float)
        {
            f = (float)o;
            Distance = f;
        }
        else if (o is int)
        {
            f = (float)(int)o;
            Distance = f;
        }
        else if (float.TryParse(o.ToString(),out f))
        {
            Distance = f;
        }
    }
    


}
