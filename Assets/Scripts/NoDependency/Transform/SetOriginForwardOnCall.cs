using UnityEngine;
using System.Collections;

public class SetOriginForwardOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("callSetRotation")]
	public string Incoming;

    private Transform targetTransform;

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
            if(o is Vector3)
            {
                cachedOriginTransform.rotation = Quaternion.LookRotation((Vector3)o);
            }
        });
    }

    private void SetRotation(Transform targetToMatch)
    {
        cachedOriginTransform.localRotation = targetToMatch.localRotation;
    }
}
