using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendRayParameterWithPlaneProjectionOnCall : Base {

    public string CallSendProjectedRay, OutgoingProjectedRay;
    public string CallSetPlaneNormal;
    public Vector3 PlaneNormal;

    public void Awake()
    {
        CacheMethod(CallSetPlaneNormal, SetPlaneNormal);
        CacheMethod(CallSendProjectedRay, SendProjectedRay);
    }
    private void SendProjectedRay(object o)
    {
        if(o is Ray)
        {
            Ray ray = (Ray)o;
            ray.direction = Vector3.ProjectOnPlane(ray.direction, PlaneNormal);
            Call(OutgoingProjectedRay, cachedGameObject, ray);
        }
    }
    private void SetPlaneNormal(object o)
    {
        if(o is Vector3)
        {
            PlaneNormal = (Vector3)o;
        }
    }
}
