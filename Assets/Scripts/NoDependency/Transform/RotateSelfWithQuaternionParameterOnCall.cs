using UnityEngine;
using System.Collections;

public class RotateSelfWithQuaternionParameterOnCall : Base {

    public string Incoming;

    void Awake()
    {
        CacheMethod(Incoming, Rotate);
    }
    void Rotate(object o)
    {
        if(o is Quaternion)
        {
            cachedTransform.rotation *= (Quaternion)o;
        }
    }
}
