using UnityEngine;
using System.Collections;

public class SendDirectionOnCall : Base {
	public Vector3 From;
	public Vector3 To;

	public string CallSetFrom;
	public string CallSetTo;
	public string CallSend;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(CallSetFrom, SetFrom);
		CacheMethod(CallSetTo, SetTo);
		CacheMethod(CallSend, Send);
	}

	private void SetFrom(object o)
	{
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}

		if(o is Transform) {
			o = ((Transform)o).position;
		}
		
		if(o is Vector3) {
			From = (Vector3) o;
		}
	}

	private void SetTo(object o)
	{
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}

		if(o is Transform) {
			o = ((Transform)o).position;
		}
		
		if(o is Vector3) {
			To = (Vector3) o;
		}
	}

	private void Send(object o)
	{
		Vector3 direction = (To - From).normalized;
		Call(Outgoing, cachedGameObject, direction);
	}
}
