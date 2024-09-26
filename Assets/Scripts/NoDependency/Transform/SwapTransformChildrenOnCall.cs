using UnityEngine;
using System.Collections.Generic;

public class SwapTransformChildrenOnCall : Base
{

    [UnityEngine.Serialization.FormerlySerializedAs("incoming")]
    public string Incoming;
    [UnityEngine.Serialization.FormerlySerializedAs("worldPositionStays")]
    public bool WorldPositionStays;
    void Start()
    {
        CacheMethod(Incoming, SwapChildren);
    }
    void SwapChildren(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Swap(transform, (Transform)o);
        }
    }
    void Swap(Transform t1, Transform t2)
    {
        List<Transform> children1 = new List<Transform>();
        List<Transform> children2 = new List<Transform>();



        for (int i = 0, c = t1.childCount; i < c; ++i)
        {
            children1.Add(t1.GetChild(i));
        }
        for (int i = 0, c = t2.childCount; i < c; ++i)
        {
            children2.Add(t2.GetChild(i));
        }
        for (int i = 0, c = children1.Count; i < c; ++i)
        {
            children1[i].SetParent(t2, WorldPositionStays);
        }
        for (int i = 0, c = children2.Count; i < c; ++i)
        {
            children2[i].SetParent(t1, WorldPositionStays);
        }

    }

}
