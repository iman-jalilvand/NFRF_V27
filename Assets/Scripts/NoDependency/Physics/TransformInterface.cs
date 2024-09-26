using UnityEngine;

public class TransformInterface : Base
{
    public Transform Target;
    public string CallSetPosition;
    public string CallGetLocalPosition;
    public string OutgoingOnGetLocalPosition;
    // Use this for initialization
    void Awake()
    {
        CacheMethod(CallSetPosition, SetPosition);
        CacheMethod(CallGetLocalPosition, (o) =>
        {
            Call(OutgoingOnGetLocalPosition, cachedGameObject, cachedTransform.localPosition);
        });
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
