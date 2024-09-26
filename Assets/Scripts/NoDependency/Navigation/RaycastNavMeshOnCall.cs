using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastNavMeshOnCall : Base
{

    public string CallRaycast;
    public string OutgoingOnHit;
    public string OutgoingOnMiss;

    public string CallSetStartPoint;
    public string CallSetEndPoint;

    public Vector3 StartPoint;
    public Vector3 EndPoint;
    void Awake()
    {
        CacheMethod(CallRaycast, Cast);
        CacheMethod(CallSetStartPoint, SetStartPoint);
        CacheMethod(CallSetEndPoint, SetEndPoint);
    }
    void SetStartPoint(object o)
    {
        if (o is Vector3)
        {
            StartPoint = (Vector3)o;
        }
    }
    void SetEndPoint(object o)
    {
        if (o is Vector3)
        {
            EndPoint = (Vector3)o;
        }
    }
    public float duration = 1;
    void Cast(object o)
    {
        NavMeshHit hit;
        Debug.DrawLine(StartPoint, EndPoint, Color.green, duration);
        if (NavMesh.Raycast(StartPoint, EndPoint, out hit, NavMesh.AllAreas))
        {
            Call(OutgoingOnHit, cachedGameObject, hit);
            Debug.DrawLine(StartPoint, hit.position, Color.red, duration);
        }
        else
        {
            Call(OutgoingOnMiss, cachedGameObject, hit);
        }
    }
}
