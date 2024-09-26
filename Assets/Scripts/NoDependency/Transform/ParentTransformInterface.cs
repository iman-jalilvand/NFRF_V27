using UnityEngine;
using System.Collections;

public class ParentTransformInterface : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("target")]
	private Transform Target;
    public string CallSetPosition;

    // Use this for initialization
    void Awake()
    {
        UpdateCachedFields();
        Target = cachedTransform.parent;
        CacheMethod(CallSetPosition, SetPosition);
    }

    private void SetPosition(object o)
    {
        if (o is Transform)
        {
            SetPosition((Transform)o);
        }
        else if (o is GameObject)
        {
            SetPosition((GameObject)o);
        }
    }

    private void SetPosition(Transform t)
    {
        Target.position = t.position;
    }
    private void SetPosition(GameObject t)
    {
        SetPosition(t.transform);
    }
}