using UnityEngine;
using System.Collections;

public class SpherecastAllOnCall : Base
{

    public string CallSpherecast;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoingHitKey")]
    public string OutgoingOnHit;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoingMissKey")]
    public string OutgoingOnMiss;
    public string CallSetRay;
    public string CallSetDirection;
    public string CallSetOrigin;

    [UnityEngine.Serialization.FormerlySerializedAs("layer")]
    public LayerMask Layer;
    [UnityEngine.Serialization.FormerlySerializedAs("origin")]
    public Vector3 Origin;
    [UnityEngine.Serialization.FormerlySerializedAs("direction")]
	public Vector3 Direction;
    [UnityEngine.Serialization.FormerlySerializedAs("radius")]
    public float Radius;
    [UnityEngine.Serialization.FormerlySerializedAs("distance")]
    public float Distance = Mathf.Infinity;

    // Use this for initialization
    void Start()
    {
        CacheMethod(CallSpherecast, Spherecast);
        CacheMethod(CallSetRay, SetRay);
        CacheMethod(CallSetDirection, SetDirection);
        CacheMethod(CallSetOrigin, SetOrigin);
    }
    void Spherecast(object o)
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(Origin, Radius, Direction, Distance, Layer.value);
        if (hits.Length > 0)
        {
            Call(OutgoingOnHit, cachedGameObject, hits);
        }
        else
        {
            Call(OutgoingOnMiss, cachedGameObject, hits);
        }
    }
    void SetRay(object o)
    {
        if (o is Ray)
        {
            Ray ray = (Ray)o;
            Origin = ray.origin;
            Direction = ray.direction;
        }
    }
    void SetDirection(object o)
    {
        if (o is Vector3)
        {
            Direction = (Vector3)o;
        }
    }

    void SetOrigin(object o)
    {
        if (o is Vector3)
        {
            Origin = (Vector3)o;
        }
    }
}
