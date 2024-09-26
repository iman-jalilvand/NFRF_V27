using UnityEngine;
using System.Collections;

public class SelfSendForwardRayOnUpdate : Base
{
    public string OutgoingRay;
    public string OutgoingOnHit;
    public string OutgoingOnMiss;
    [UnityEngine.Serialization.FormerlySerializedAs("distance")]
	public float Distance;

    private void Update()
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
            Call(OutgoingOnMiss, cachedGameObject);
        }
    }
}
