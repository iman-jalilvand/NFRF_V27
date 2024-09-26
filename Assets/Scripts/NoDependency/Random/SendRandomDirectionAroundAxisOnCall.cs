using UnityEngine;
using System.Collections;

public class SendRandomDirectionAroundAxisOnCall : Base {

    public string Incoming, Outgoing;
    public Vector3 Axis;
    private Vector3 unitVector;
    void Awake()
    {
        CacheMethod(Incoming,SendDirection);
    }
    void SendDirection(object o)
    {
        Vector3 output = GetRandomPointOnCircle();
        Call(Outgoing, cachedGameObject, output);
    }
    Vector3 GetRandomPointOnCircle()
    {
        Vector3 dir = Vector3.forward;
        dir = Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0) * dir;
        dir = (Quaternion.Inverse(Quaternion.LookRotation(Axis))) * dir;
        return dir;
    }
}
