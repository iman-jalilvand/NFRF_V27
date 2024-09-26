using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastNavMeshFromTargetOnCall : Base {

    public string CallRaycast;
    public string OutgoingOnHit;
    public string OutgoingOnMiss;

    public string CallSetTarget;
    public string CallSetEndPoint;

    public Transform Target;
    public Vector3 EndPoint;
    void Awake()
    {
        CacheMethod(CallRaycast, Cast);
        CacheMethod(CallSetTarget, SetTarget);
        CacheMethod(CallSetEndPoint, SetEndPoint);
    }
    void SetTarget(object o)
    {
        if(o is GameObject)
        {
            Target = ((GameObject)o).transform;
        }
        else if(o is Transform)
        {
            Target = (Transform)o;
        }
        else if(o is Component)
        {
            Target = ((Component)o).transform;
        }
    }
    void SetEndPoint(object o)
    {
        if (o is Vector3)
        {
            EndPoint = (Vector3)o;
        }
    }
    void Cast(object o)
    {
        if (o is Vector3)
        {
            NavMeshHit hit;
            if (NavMesh.Raycast(Target.position, EndPoint, out hit, NavMesh.AllAreas))
            {
                Call(OutgoingOnHit, cachedGameObject, hit);
                Debug.DrawLine(Target.position, EndPoint, Color.cyan,5);
                Debug.DrawLine(Target.position, hit.position,Color.green,5);
            }
            else
            {
                Call(OutgoingOnMiss, cachedGameObject, hit);
            }
        }
    }
}
