using UnityEngine;
using System.Collections;

public class RaycastOnCall : Base {

    public string Incoming;
	public string OutgoingOnHit;
	public string OutgoingOnMiss;
    public string CallSetRay;
    public string CallSetDistance;
	public string CallSetDirection;
	public string CallSetOrigin;

    [UnityEngine.Serialization.FormerlySerializedAs("layer")]
	public LayerMask Layer;
    [UnityEngine.Serialization.FormerlySerializedAs("origin")]
	public Vector3 Origin;
	[UnityEngine.Serialization.FormerlySerializedAs("direction")]
	public Vector3 Direction;
    [UnityEngine.Serialization.FormerlySerializedAs("distance")]
	public float Distance = Mathf.Infinity;

	// Use this for initialization
	void Start ()
    {
        CacheMethod(Incoming, RayCast);
        CacheMethod(CallSetRay, SetRay);
        CacheMethod(CallSetDirection, SetDirection);
        CacheMethod(CallSetDistance, SetDistance);
        CacheMethod(CallSetOrigin, SetOrigin);
    }
	void RayCast(object o)
    {
        RaycastHit hit;
        if (Physics.Raycast(Origin, Direction, out hit, Distance,Layer.value))
        {
            Call(OutgoingOnHit, cachedGameObject, hit);
        }
        else
        {
            Call(OutgoingOnMiss, cachedGameObject, hit);
        }
    }
    void SetRay(object o)
    {
        if(o is Ray)
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

    void SetDistance(object o)
    {
        if (o is float)
        {
            Distance = (float)o;
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
