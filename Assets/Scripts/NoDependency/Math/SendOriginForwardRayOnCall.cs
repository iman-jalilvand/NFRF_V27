using UnityEngine;
using System.Collections;

public class SendOriginForwardRayOnCall : Base
{
    public string Incoming;
    public string OutgoingRay;
    public string OutgoingKey;
    public string OutgoingMiss;
    public float Distance;

    void Start()
    {
        CacheMethod(Incoming, FireRay);
    }
    private void FireRay(object o)
    {
        Ray ray = new Ray(cachedOriginTransform.position, cachedOriginTransform.forward);
        Call(OutgoingRay, cachedGameObject, ray);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, Distance))
        {
            Call(OutgoingKey, cachedGameObject, hit);
        }
        else
        {
            hit = new RaycastHit();
            hit.distance = Distance;
            hit.point = ray.GetPoint(Distance);
            hit.normal = -ray.direction;
            Call(OutgoingMiss, cachedGameObject, hit);
        }
    }
}
