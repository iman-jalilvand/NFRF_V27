using UnityEngine;
using System.Collections;

public class SendVector3ParameterAsNavMeshPosition : Base {

    public string Incoming, Outgoing;

    void Awake()
    {
        CacheMethod(Incoming, GetPosition);
    }
    public void GetPosition(object o)
    {
        if(o is GameObject)
        {
            o = ((GameObject)o).transform.position;
        }
        if(o is Transform)
        {
            o = ((Transform)o).position;
        }
        if(o is Vector3)
        {
            Vector3 inputVec = (Vector3)o;
            UnityEngine.AI.NavMeshHit hit;
            if(UnityEngine.AI.NavMesh.SamplePosition(inputVec, out hit, 3.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                Call(Outgoing, cachedGameObject, hit.position);
            }
        }
    }
}
