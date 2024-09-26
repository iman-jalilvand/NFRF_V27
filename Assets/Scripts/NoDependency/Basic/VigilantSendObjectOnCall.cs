using UnityEngine;
using System.Collections;

public class VigilantSendObjectOnCall : Base
{
    public Object Obj;
    public string CallSend;
    public string CallSetObject;
    public string Outgoing;

    private void Awake()
    {
        base.OnEnable();

        CacheMethod(CallSend, Send);
        CacheMethod(CallSetObject, Store);
    }

    private void OnDestroy()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        //
    }

    protected override void OnDisable()
    {
        //
    }

    private void Store(object o)
    {
        if (o is Object)
        {
            Obj = o as Object;
        }
    }
    private void Send(object o)
    {
        Call(Outgoing, cachedGameObject, Obj);
    }
}
