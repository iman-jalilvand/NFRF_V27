using UnityEngine;
using System.Collections;

public class SendVector3ParameterAddedWithTargetPositionOnCall : Base
{

	public string CallSend;
	public string Outgoing;
	public string CallSetTarget;

    public Transform Target;

	private void Awake()
	{
		UpdateCachedFields();
		CacheMethod(CallSetTarget, SetTarget);
		CacheMethod(CallSend, Add);
	}

    private void SetTarget(object o)
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

    private void Add(object o)
	{
		if (o is Vector3)
		{
			Call(Outgoing, cachedGameObject, ((Vector3)o) + Target.position);
		}
	}
}
