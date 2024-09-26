using UnityEngine;
using System.Collections;

public class VigilantDrawDebugLineFromSelfOnCall : Base {
    public string Incoming;
    public Color LineColor = Color.white;
    public float Scale = 1;
    public float Duration;
    void Awake()
    {
        CacheMethod(Incoming, DrawLine);
    }
	void DrawLine(object o)
    {
        Debug.DrawLine(cachedTransform.position, cachedTransform.position+(Vector3)o,LineColor, Duration);
    }
}
