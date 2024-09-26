using UnityEngine;

public class SelfSendForwardRayOnCall : Base
{
    public string Incoming;
    public string OutgoingRay;
    public string OutgoingOnHit;
    public string OutgoingOnMiss;
    [UnityEngine.Serialization.FormerlySerializedAs("distance")]
	public float Distance;

    void Start()
    {
        CacheMethod(Incoming, FireRay);
    }
    private void FireRay(object o)
    {
        Ray ray = new Ray(cachedTransform.position, cachedTransform.forward);
        Call(OutgoingRay, cachedGameObject, ray);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, Distance))
        {
            Call(OutgoingOnHit, cachedGameObject, hit);
        }
        else
        {
            hit = new RaycastHit();
            hit.distance = Distance;
            hit.point = ray.GetPoint(Distance);
            hit.normal = -ray.direction;
            Call(OutgoingOnMiss, cachedGameObject, hit);
        }
    }
}
