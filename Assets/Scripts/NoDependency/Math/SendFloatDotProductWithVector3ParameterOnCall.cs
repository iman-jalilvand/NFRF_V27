using UnityEngine;
using System.Collections;

public class SendFloatDotProductWithVector3ParameterOnCall : Base
{

	public Vector3 Target;
	public string Incoming;
	public string Outgoing;
	public string CallSetTarget;

	void Awake()
	{
		CacheMethod(Incoming, Dot);
		CacheMethod(CallSetTarget, SetLeft);
	}

    void Dot(object o)
    {
        if (o is Vector3)
        {
            Call(Outgoing, cachedGameObject, Vector3.Dot(Target, (Vector3)o));
        }
    }

	void SetLeft(object o)
	{
		if (o is Vector3)
		{
			Target = (Vector3)o;
		}
	}

}
