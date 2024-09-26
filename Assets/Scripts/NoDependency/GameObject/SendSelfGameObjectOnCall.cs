using UnityEngine;
using System.Collections;

public class SendSelfGameObjectOnCall : Base {
	public string Incoming;
	public string Outgoing;
	public Behaviour SendTo;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
	}

    private void Send(object o)
    {
        switch(SendTo)
        {
            case Behaviour.Self:
                Call(Outgoing, cachedGameObject, cachedGameObject);
                break;
            case Behaviour.All:
                Call(Outgoing, typeof(Base), cachedGameObject);
                break;
        }
    }

    public enum Behaviour
    {
        Self,
        All
    }
}
