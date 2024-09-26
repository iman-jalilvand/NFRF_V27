using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class SendVector3SumOnCall : Base
{
    public bool ClearSumOnSend = true;
    public string CallSendSum;
    public string Outgoing;
    public string CallSetSum;
    public string CallAddToSum;
    public Vector3 Sum = Vector3.zero;
    void Awake()
    {
        CacheMethod(CallSendSum, SendSum);
        CacheMethod(CallAddToSum, AddToSum);
        CacheMethod(CallSetSum, SetSum);
    }
    void SetSum(object o)
    {
        if(o is Vector3)
        {
            Sum = (Vector3)o;
        }
    }
    void SendSum(object o)
    {
        Call(Outgoing, cachedGameObject, Sum);
        if(ClearSumOnSend)
        {
            Sum = Vector3.zero;
        }
    }
    void AddToSum(object o)
    {
        if(o is Vector3)
        {
            Sum += (Vector3)o;
        }
    }
}