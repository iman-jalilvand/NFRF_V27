using UnityEngine;
using System.Collections;

public class SendAnimatorComponentFromGameObjectParameterOnCall : Base
{
    public string Incoming, Outgoing;

    void Awake()
    {
        CacheMethod(Incoming, Send);
    }
    void Send(object o)
    {
        if(o is GameObject)
        {
            Call(Outgoing,cachedGameObject,((GameObject)o).GetComponent<Animator>());
        }
        else if (o is Transform)
        {
            Call(Outgoing, cachedGameObject, ((Transform)o).gameObject.GetComponent<Animator>());
        }
    }
}
