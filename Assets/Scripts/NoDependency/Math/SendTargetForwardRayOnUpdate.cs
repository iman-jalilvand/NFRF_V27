using UnityEngine;
using System.Collections;

public class SendTargetForwardRayOnUpdate : Base
{
    public Transform Target;
    public string OutgoingRay;
    public string OutgoingHit;
    public string OutgoingMiss;
    public float Distance;

    private void Update()
    {
        Ray ray = new Ray(Target.position, Target.forward);
        Call(OutgoingRay, cachedGameObject, ray);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Distance))
        {
            Call(OutgoingHit, cachedGameObject, hit);
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
