using UnityEngine;
using System.Collections;

public class SendParentRigidbodyFromParameterOnCall : Base {
	public string Incoming;
	public string Outgoing;
	public Output OutputParameterType;

	private void Awake()
	{
		CacheMethod(Incoming, Extract);
	}

	private void Extract(object o)
	{
		Rigidbody rb = null;
		if(o is GameObject)
		{
			rb = ((GameObject)o).GetComponentInParent<Rigidbody>();
		}

		Send(rb);
	}

	private void Send(Rigidbody rb)
	{
		if(rb == null) {
			return;
		}

		switch(OutputParameterType) {
			case Output.GameObject:
				Call(Outgoing, cachedGameObject, rb.gameObject);
			break;
			case Output.Rigidbody:
				Call(Outgoing, cachedGameObject, rb);
			break;
		}
	}



	public enum Output
	{
		Rigidbody,
		GameObject
	}
}
