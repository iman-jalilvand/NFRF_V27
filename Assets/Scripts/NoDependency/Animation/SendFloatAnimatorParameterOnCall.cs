using UnityEngine;
using System.Collections;

public class SendFloatAnimatorParameterOnCall : Base
{
    public string Incoming, Outgoing;
    public string CallSetParameter;
    public string Parameter;

    void Awake()
    {
        CacheMethod(Incoming, Send);
        CacheMethod(CallSetParameter, SetParameter);
    }
    void Send(object o)
    {
        if(o is Animator)
        {
            Call(Outgoing,cachedGameObject,((Animator)o).GetFloat(Parameter));
        }
    }
    void SetParameter(object o)
    {
        if (o is string)
        {
            Parameter = (string)o;
        }
    }
}
