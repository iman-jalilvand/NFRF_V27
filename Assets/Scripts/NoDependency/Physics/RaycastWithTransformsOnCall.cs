using UnityEngine;

public class RaycastWithTransformsOnCall : Base
{

    public string Incoming;
	public string OutgoingOnHit;
	public string OutgoingOnMiss;
    public string CallSetDestination;
	public string CallSetOrigin;

    [UnityEngine.Serialization.FormerlySerializedAs("layer")]
	public LayerMask Layer;
    [UnityEngine.Serialization.FormerlySerializedAs("origin")]
	public Transform Origin;
	[UnityEngine.Serialization.FormerlySerializedAs("destination")]
	public Transform Destination;
    [UnityEngine.Serialization.FormerlySerializedAs("distance")]
	public float Distance = Mathf.Infinity;

    // Use this for initialization
    void Start()
    {
        Origin = cachedTransform;
        CacheMethod(Incoming, RayCast);
        CacheMethod(CallSetDestination, SetDestination);
        CacheMethod(CallSetOrigin, SetOrigin);
    }
    void RayCast(object o)
    {
        RaycastHit hit;
        Vector3 ray = Destination.position - Origin.position;
        if (Physics.Raycast(Origin.position, ray, out hit, Distance, Layer.value))
        {
            Call(OutgoingOnHit, cachedGameObject, hit);
        }
        else
        {
            Call(OutgoingOnMiss, cachedGameObject, hit);
        }
    }
    void SetDestination(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Destination = (Transform)o;
        }
    }

    void SetOrigin(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Origin = (Transform)o;
        }
    }
}
