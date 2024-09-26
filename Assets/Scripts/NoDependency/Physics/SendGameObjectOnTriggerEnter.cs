using UnityEngine;
using System.Collections;

public class SendGameObjectOnTriggerEnter : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
    public string Outgoing;
	[UnityEngine.Serialization.FormerlySerializedAs("sendTo")]
    public Option SendTo;
	[UnityEngine.Serialization.FormerlySerializedAs("parameter")]
	public Option Parameter;

    private void OnTriggerEnter(Collider c)
    {
        GameObject target = ExtractGameObject(SendTo, c);
		GameObject parameterGO = ExtractGameObject(Parameter, c);
        Call(Outgoing, target, parameterGO);
    }
	
	private GameObject ExtractGameObject(Option o, Collider c)
	{
		GameObject result;
		switch(o) {
			case Option.Self:
				result = cachedGameObject;
				break;
			case Option.Other:
			default:
				result = c.gameObject;
				break;
		}

		return result;
	}

    public enum Option
    {
        Self,
        Other
    }
}
