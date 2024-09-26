using UnityEngine;

public class SpherecastOnCall : Base
{
    public string CallSpherecast;
    public string OutgoingOnHit;
    public string OutgoingOnMiss;
    public string CallSetRay;
    public string CallSetDirection;
    public string CallSetOrigin;
    public string CallSetDistance;

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
        CacheMethod(CallSpherecast, RayCast);
        CacheMethod(CallSetRay, SetRay);
        CacheMethod(CallSetDirection, SetDirection);
        CacheMethod(CallSetOrigin, SetOrigin);
        CacheMethod(CallSetDistance, SetDistance);
    }
    void RayCast(object o)
    {
        RaycastHit hit;
        if (Physics.SphereCast(Origin, Radius, Direction, out hit, Distance, Layer.value))
        {
            Call(OutgoingOnHit, cachedGameObject, hit);
        }
        else
        {
            Call(OutgoingOnMiss, cachedGameObject, hit);
        }
    }
    void SetDistance(object o)
    {
        float f;
        if(o is float)
        {
            f = (float)o;
            Distance = f;
        }
        else if (o is float)
        {
            f = (float)o;
            Distance = f;
        }
        else if(float.TryParse(o.ToString(),out f))
        {
            Distance = f;
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
