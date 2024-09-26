using UnityEngine;
using System.Collections;

public class SendClampedVectorParameterOnCall : Base {

    public string Incoming, Outgoing;
    public float MagnitudeClamp;
	// Use this for initialization
	void Awake () {
        CacheMethod(Incoming, SendClampedVector);
	}
	void SendClampedVector(object o)
    {
        if(o is Vector3)
        {
            Vector3 output = Vector3.ClampMagnitude((Vector3)o, MagnitudeClamp);
            Call(Outgoing, cachedGameObject, output);
        }
    }
}
