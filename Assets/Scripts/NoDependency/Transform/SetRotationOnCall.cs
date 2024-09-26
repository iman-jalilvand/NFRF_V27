using UnityEngine;
using System.Collections;

public class SetRotationOnCall : Base
{
	public string Incoming;
	public bool IsLocal = true;
    private Transform targetTransform;

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
            if (o is GameObject)
            {
                o = ((GameObject)o).transform;
            }

            if (o is Transform)
            {
                targetTransform = (Transform)o;
                SetRotation(targetTransform);
            }
        });
    }

    private void SetRotation(Transform targetToMatch)
    {
		if(IsLocal) {
			cachedTransform.localRotation = targetToMatch.localRotation;
		} else {
			CachedTransform.rotation = targetToMatch.rotation;
		}
    }
}
