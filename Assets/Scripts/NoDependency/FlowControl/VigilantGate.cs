using UnityEngine;
using System.Collections;

public class VigilantGate : Base
{
	public bool Open;
	public string Incoming;
	public string Outgoing;
	public string CallCloseGate;
	public string CallOpenGate;
	public string CallSetGate;

    private void Awake()
    {
		base.OnEnable();
        CacheMethod(Incoming, IncomingMethod);
        CacheMethod(CallCloseGate, CloseGate);
        CacheMethod(CallOpenGate, OpenGate);
        CacheMethod(CallSetGate, SetGate);
    }

	protected override void OnEnable()
	{
		//
	}

	protected override void OnDisable()
	{
		//
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}

	private void SetGate(object o)
    {
        bool b;
		if(o is bool) {
			Open = (bool) o;
		} else if (bool.TryParse(o.ToString(), out b))
        {
            Open = b;
        }
    }

    private void CloseGate(object o)
    {
        Open = false;
    }

    private void OpenGate(object o)
    {
        Open = true;
    }

    private void IncomingMethod(object o)
    {
        if (Open)
        {
            Call(Outgoing, cachedGameObject, o);
        }
    }
}
