using UnityEngine;
using System.Collections;

public class SendTransformOnCall : Base
{
	public string Incoming;
	public string Outgoing;
    public string CallSetTransform;
	public Transform Parameter;
	public Behaviour SendTo;

	void Awake()
    {
        CacheMethod(Incoming, Send);
        CacheMethod(CallSetTransform, SetTargetTransform);
    }
    private void SetTargetTransform(object o)
    {
        if(o is GameObject)
        {
            Parameter = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Parameter = (Transform)o;
        }
    }
	private void Send(object o)
	{
		switch (SendTo)
		{
			case Behaviour.Self:
				Call(Outgoing, cachedGameObject, Parameter);
				break;
			case Behaviour.All:
				Call(Outgoing, typeof(Base), Parameter);
				break;
		}
	}

	public enum Behaviour
	{
		Self,
		All
	}
}
