using UnityEngine;
using System.Collections;

public class VigilantSendTransformFromParameterGameObjectOnCall : Base
{
    public string Incoming, Outgoing;
    // Use this for initialization
    void Awake()
    {
        base.OnEnable();
        CacheMethod(Incoming,SendTransform);
    }
    // Use this for initialization
    void OnDestroy()
    {
        base.OnDisable();
    }
    void SendTransform(object o)
    {
        if(o is GameObject)
        {
            Call(Outgoing, cachedGameObject, ((GameObject)o).transform);
        }
    }
    protected override void OnDisable() { }
    protected override void OnEnable() { }
}
