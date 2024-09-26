using UnityEngine;
using System.Collections;

public class SendGameObjectParameterAnimatorOnCall : Base
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
            Animator animator = ((GameObject)o).GetComponent<Animator>();
            Call(Outgoing, cachedGameObject, animator);
        }
    }
}
