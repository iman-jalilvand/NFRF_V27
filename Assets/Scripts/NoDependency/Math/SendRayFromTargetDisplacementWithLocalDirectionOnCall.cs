using UnityEngine;
using System.Collections;

public class SendRayFromTargetDisplacementWithLocalDirectionOnCall : Base
{
    public Transform Target;
    public Vector3 Direction;
    public Vector3 Displacement;
    public string CallSetTarget;
    public string CallSetDisplacement;
    public string CallSetDirection;
    public string CallSendRay;
	public string Outgoing;
    void Start()
    {
        CacheMethod(CallSendRay, SendRay);
        CacheMethod(CallSetTarget, SetTarget);
        CacheMethod(CallSetDisplacement, SetDisplacement);
        CacheMethod(CallSetDirection, SetDirection);
    }
    void SendRay(object o)
    {
        Vector3 worldDirection = Target.TransformDirection(Direction);
        Ray ray = new Ray(Target.position + Displacement, worldDirection);
        Debug.DrawLine(ray.origin, ray.origin + ray.GetPoint(50),Color.red);
        Call(Outgoing, cachedGameObject, ray);
    }
    void SetDisplacement(object o)
    {
        if(o is Vector3)
        {
            Displacement = (Vector3)o;
        }
    }
    void SetTarget(object o)
    {
        if (o is Transform)
        {
            Target = (Transform)o;
        }
    }
    void SetDirection(object o)
    {
        if (o is Vector3)
        {
            Direction = (Vector3)o;
        }
        else if (o is Quaternion)
        {
            Direction = ((Quaternion)o).eulerAngles;
        }
    }
}
