using UnityEngine;
using System.Collections;

public class SendVector3ParameterTransformDirectionWithTargetOnCall : Base {
	public string CallSend;
    public string Outgoing;
    public string CallSetTarget;
    public Transform Target;

	private void Awake()
	{
		CacheMethod(CallSend, TransformDirection);
        CacheMethod(CallSetTarget, SetTarget);
    }

    void SetTarget(object o)
    {
        if (o is GameObject)
        {
            Target = ((GameObject)o).transform;
        }
        else if (o is Transform)
        {
            Target = (Transform)o;
        }
        else if (o is Component)
        {
            Target = ((Component)o).transform;
        }
    }
    private void TransformDirection(object o)
    {
        if (o is Vector3)
        {
            Vector3 globalDirection = Target.TransformDirection((Vector3)o);
            Call(Outgoing, cachedGameObject, globalDirection);
        }
    }

}
