using UnityEngine;
using System.Collections;

public class SendFloatOnCall : Base {
    public string CallSend;
	public string CallSetParameter;
    public string Outgoing;
	public float Parameter;

    public Behaviour OnSend;

    void Awake ()
	{
        CacheMethod(CallSend, Send);
		CacheMethod(CallSetParameter, SetParameter);
	}

	private void SetParameter(object o)
	{
		float f;
		if(o is float) {
			Parameter = (float)o;
		} else if(float.TryParse(o.ToString(), out f)) {
			Parameter = f;
		}
	}
    private void Send(object o)
    {
        switch(OnSend)
        {
            case Behaviour.Send:
                Call(Outgoing, cachedGameObject, Parameter);
                break;
            case Behaviour.Broadcast:
                Call(Outgoing, typeof(Base), Parameter);
                break;
        }
    }

    public enum Behaviour
    {
        Send,
        Broadcast
    }
}
