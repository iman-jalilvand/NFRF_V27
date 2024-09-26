using UnityEngine;
using System.Collections;

public class SendTargetForwardRayOnCall : Base
{
    public Transform Target;
    public string Incoming;
    public string OutgoingRay;
    public string OutgoingHit;
    public string OutgoingMiss;
    [UnityEngine.Serialization.FormerlySerializedAs("distance")]
	public float Distance;

    void Start()
    {
        CacheMethod(Incoming, FireRay);
    }
    private void FireRay(object o)
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
