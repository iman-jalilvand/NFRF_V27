using UnityEngine;
using System.Collections;

public class SetWorldPositionOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("callSetPosition")]
	public string Incoming;

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
            if (o is Vector3)
            {
                SetPosition((Vector3)o);
            }
        });
    }

    private void SetPosition(Vector3 targetPosition)
    {
        cachedTransform.position = targetPosition;
    }
}
