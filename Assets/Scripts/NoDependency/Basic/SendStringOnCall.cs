
public class SendStringOnCall : Base
{
	[UnityEngine.Serialization.FormerlySerializedAs("callSend")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Outgoing, CallSetOugoing;
	[UnityEngine.Serialization.FormerlySerializedAs("parameter")]
	public string Parameter, CallSetParameter;
	[UnityEngine.Serialization.FormerlySerializedAs("onSend")]
	public Behaviour SendTo;

	void Awake()
	{
		CacheMethod(Incoming, Send);
		CacheMethod(CallSetParameter, SetParameter);
		CacheMethod(CallSetOugoing, SetOugoing);
	}
	private void SetParameter(object o)
	{
		Parameter = o.ToString();
	}
	private void SetOugoing(object o)
	{
		Outgoing = o.ToString();
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

	public void Send(string value)
	{
		Send(value as object);
	}

	public enum Behaviour
	{
		Self,
		All
	}
}
