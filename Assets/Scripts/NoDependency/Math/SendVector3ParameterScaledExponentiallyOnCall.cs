using UnityEngine;
using System.Collections;

public class SendVector3ParameterScaledExponentiallyOnCall : Base {

    public string Incoming, Outgoing;

    public Vector2 Offset;
    public Vector2 Scale;
    private Vector2 InverseScale;
    public Vector2 SetScale
    {
        set
        {
            Scale = value;
            InverseScale.x = 1 / Scale.x;
            InverseScale.y = 1 / Scale.y;
        }
    }

    void Awake()
    {
        InverseScale.x = 1 / Scale.x;
        InverseScale.y = 1 / Scale.y;
        CacheMethod(Incoming, SendScaledVector);
    }
    void SendScaledVector(object o)
    {
        if(o is Vector3)
        {
            Vector3 incoming = (Vector3)o;
            float magnitude = incoming.magnitude;
            magnitude = Mathf.Pow(magnitude * InverseScale.x-Offset.x, 2) * Scale.y+Offset.y;
            Call(Outgoing, cachedGameObject, incoming.normalized * magnitude);
        }
    }
}
