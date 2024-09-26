using UnityEngine;
using System.Collections;

public class VigilantSendFloatOnCall : Base
{
    public string CallSend;
    public string CallSetParameter;
    public string Outgoing;
    public float Parameter;

    public Behaviour OnSend;

    void Awake()
    {
        base.OnEnable();

        CacheMethod(CallSend, Send);
        CacheMethod(CallSetParameter, SetParameter);
    }

    private void SetParameter(object o)
    {
        float f;

		if(o is float) {
			f = (float)o;
		}

        if (float.TryParse(o.ToString(), out f))
        {
            Parameter = f;
        }
    }
	
    private void Send(object o)
    {
        switch (OnSend)
        {
            case Behaviour.Send:
                Call(Outgoing, cachedGameObject, Parameter);
                break;
            case Behaviour.Broadcast:
                Call(Outgoing, typeof(Base), Parameter);
                break;
        }
    }

    private void OnDestroy()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        //
    }

    protected override void OnDisable()
    {
        //
    }
    public enum Behaviour
    {
        Send,
        Broadcast
    }
}
