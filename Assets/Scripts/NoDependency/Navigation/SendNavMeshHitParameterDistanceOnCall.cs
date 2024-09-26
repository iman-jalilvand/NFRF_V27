using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;

public class SendNavMeshHitParameterDistanceOnCall : Base {
    public string CallSendPoint;
    public string OutgoingPoint;

    void Awake()
    {
        CacheMethod(CallSendPoint, Send);
    }
    void Send(object o)
    {
        if(o is NavMeshHit)
        {
            Call(OutgoingPoint, cachedGameObject, ((NavMeshHit)o).distance);
        }
    }
}
