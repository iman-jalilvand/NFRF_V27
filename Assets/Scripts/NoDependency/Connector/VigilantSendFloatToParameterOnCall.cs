using UnityEngine;
using System.Collections;

public class VigilantSendFloatToParameterOnCall : Base {
	public string CallSetFloat;
	public string Incoming;
	public string Outgoing;

	public float value;

	private void Awake()
	{
		CacheMethod(Incoming, Send);
		CacheMethod(CallSetFloat, SetFloat);
	}
    protected override void OnEnable()
    {
        //
    }
    protected override void OnDisable()
    {
        //
    }

    private void SetFloat(object o)
	{
		if(o is float) {
			value = (float) o;
		}
	}

	private void Send(object o) {
		GameObject go = o as GameObject;
		if(go == null) {
			return;
		}

		Call(Outgoing, go, value);
	}
}
