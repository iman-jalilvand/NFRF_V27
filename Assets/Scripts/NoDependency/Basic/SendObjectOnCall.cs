using UnityEngine;
public class SendObjectOnCall : Base
{
    public Object Obj;
    public string CallSend;
    public string CallSetObject;
    public string Outgoing;

    private void Awake()
    {
        CacheMethod(CallSend, Send);
        CacheMethod(CallSetObject, Store);
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
