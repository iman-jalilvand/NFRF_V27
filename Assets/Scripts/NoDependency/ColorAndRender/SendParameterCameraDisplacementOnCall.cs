using UnityEngine;
using System.Collections;

public class SendParameterCameraDisplacementOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

    private void Awake()
    {
        CacheMethod(Incoming, SendDirection);
    }

    private void SendDirection(object o)
    {
        GameObject other = o as GameObject;
        if (other == null)
        {
            return;
        }

        Vector3 dir = GetCamDirection(other.transform);
        Call(Outgoing, cachedGameObject, dir);
    }
    Vector3 GetCamDirection(Transform other)
    {
        return Camera.main.transform.position - other.position;
    }
}
