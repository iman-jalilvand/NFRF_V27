using UnityEngine;
using System.Collections;

public class SendOriginForwardRayOnUpdate : Base
{
    public string OutgoingRay;
    public string OutgoingHit;
    public string OutgoingMiss;
    [UnityEngine.Serialization.FormerlySerializedAs("distance")]
	public float Distance;

    private void Update()
    {
        Ray ray = new Ray(cachedOriginTransform.position, cachedOriginTransform.forward);
        Call(OutgoingRay, cachedGameObject, ray);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, Distance))
        {
            Call(OutgoingHit, cachedGameObject, hit);
        }
        else
        {
            Call(OutgoingMiss, cachedGameObject);
        }
    }
}
