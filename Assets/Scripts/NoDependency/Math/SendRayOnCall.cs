using UnityEngine;
using System.Collections;
using System;

public class SendRayOnCall : Base
{
    public string CallSendRay, OutgoingRay;
    public string CallSetOrigin, CallSetDirection;
    public Vector3 Origin,Direction;

    public void Awake()
    {
        CacheMethod(CallSetOrigin, SetOrigin);
        CacheMethod(CallSetDirection, SetDirection);
        CacheMethod(CallSendRay, SendRay);
    }
    private void SetOrigin(object o)
    {
        if (o is Vector3)
        {
            Origin = (Vector3)o;
        }
    }
    private void SetDirection(object o)
    {
        if (o is Vector3)
        {
            Direction = (Vector3)o;
        }
    }
    public void SendRay(object o)
    {
        Ray ray = new Ray(Origin, Direction);
        Call(OutgoingRay, cachedGameObject, ray);
    }
}