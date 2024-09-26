using UnityEngine;
using System.Collections;

public class SendFloatDegreeAngleBetweenTwoProjectedOnPlaneVector3sOnCall : Base {
	public string CallSetAngle1, CallSetAngle2, CallSetPlaneNormal, CallCalculate;
    public string outgoingAngleMethodName;

    public Vector3 Normal = Vector3.up;
    private Vector3 angle1, angle2;
    Transform target;
    private void Awake()
    {
        CacheMethod(CallSetAngle1, SetAngle1);
        CacheMethod(CallSetAngle2, SetAngle2);
        CacheMethod(CallSetPlaneNormal, SetNormal);
        CacheMethod(CallCalculate, Calculate);
	}
    void Start()
    {
        target = Camera.main.transform;
    }
	private void SetAngle1(object o)
	{
		if(o is Vector3)
		{
			angle1 = (Vector3) o;
			angle1.Normalize();
		}
    }

    private void SetAngle2(object o)
    {
        if (o is Vector3)
        {
            angle2 = (Vector3)o;
            angle2.Normalize();
        }
    }

    private void SetNormal(object o)
    {
        if (o is Vector3)
        {
            Normal = (Vector3)o;
            Normal.Normalize();
        }
    }

    private void Calculate(object o)
    {
        Vector3 ang1 = Vector3.ProjectOnPlane(angle1, Normal);
        Vector3 ang2 = Vector3.ProjectOnPlane(angle2, Normal);
        float angle = Vector3.Angle(ang1, ang2);
		Call(outgoingAngleMethodName, cachedGameObject, angle);
	}
}
