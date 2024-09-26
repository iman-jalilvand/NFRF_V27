using UnityEngine;
using System.Collections;

public class SendFloatDegreeAngleBetweenTwoVector3sOnCall : Base {
	public string CallSetAngle1, CallSetAngle2, CallCalculate;
	public string Outgoing;

	public Vector3 Angle1, Angle2;
    private void Awake()
    {
        CacheMethod(CallSetAngle1, SetAngle1);
		CacheMethod(CallSetAngle2, SetAngle2);
		CacheMethod(CallCalculate, Calculate);
	}

	private void SetAngle1(object o)
	{
		if(o is Vector3)
		{
			Angle1 = (Vector3) o;
			Angle1.Normalize();
		}
	}

	private void SetAngle2(object o)
	{
		if(o is Vector3)
		{
			Angle2 = (Vector3) o;
			Angle2.Normalize();
		}
	}

	private void Calculate(object o)
    {
        float angle = Vector3.Angle(Angle1, Angle2);
		Call(Outgoing, cachedGameObject, angle);
	}
}
