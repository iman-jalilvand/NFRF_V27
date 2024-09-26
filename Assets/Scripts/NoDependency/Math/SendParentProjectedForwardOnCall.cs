using UnityEngine;
using System.Collections;

public class SendParentProjectedForwardOnCall : Base
{
    public string Incoming;
    public string Outgoing;
    void Start()
    {
        UpdateCachedFields();
        CacheMethod(Incoming, SetForward);
    }
    void SetForward(object o)
    {
        Call(Outgoing, cachedTransform.parent.gameObject, Vector3.ProjectOnPlane(cachedTransform.forward,Vector3.up).normalized);
    }
}