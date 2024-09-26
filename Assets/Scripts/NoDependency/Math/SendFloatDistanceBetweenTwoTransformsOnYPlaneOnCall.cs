using UnityEngine;
using System.Collections;

public class SendFloatDistanceBetweenTwoTransformsOnYPlaneOnCall : Base
{
    public string CallCalculate, CallSetSourceA, CallSetSourceB;
    public string Outgoing;

    public Transform SourceA, SourceB;

    private void Awake()
    {
        CacheMethod(CallCalculate, Calculate);
        CacheMethod(CallSetSourceA, SetSourceA);
        CacheMethod(CallSetSourceB, SetSourceB);
    }

    private void Calculate(object o)
    {
        if (SourceA == null || SourceB == null)
        {
            return;
        }

        float distance = Vector3.Distance(new Vector3(SourceA.position.x, 0, SourceA.position.z), new Vector3(SourceB.position.x, 0, SourceB.position.z));
        Call(Outgoing, cachedGameObject, distance);
    }

    private void SetSourceA(object o)
    {
        SourceA = CastToTransform(o);
    }

    private void SetSourceB(object o)
    {
        SourceB = CastToTransform(o);
    }

    private Transform CastToTransform(object o)
    {
        Transform trans = null;
        if (o is GameObject)
        {
            trans = ((GameObject)o).transform;
        }

        if (o is Transform)
        {
            trans = (Transform)o;
        }

        return trans;
    }
}