using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class SendFloatSumOnCall : Base
{
    public bool ClearSumOnSend = true;
    public string CallSendSum;
    public string Outgoing;
    public string CallSetSum;
    public string CallAddToSum;
    public float Sum;
    void Awake()
    {
        CacheMethod(CallSendSum, SendSum);
        CacheMethod(CallAddToSum, AddToSum);
        CacheMethod(CallSetSum, SetSum);
    }
    void SetSum(object o)
    {
        if(o is float)
        {
            Sum = (float)o;
        }
    }
    void SendSum(object o)
    {
        Call(Outgoing, cachedGameObject, Sum);
        if(ClearSumOnSend)
        {
            Sum = 0;
        }
    }
    void AddToSum(object o)
    {
        if(o is float)
        {
            Sum += (float)o;
        }
    }
}