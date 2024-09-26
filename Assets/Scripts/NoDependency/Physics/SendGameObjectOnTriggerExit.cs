using UnityEngine;

public class SendGameObjectOnTriggerExit : Base {
    public string Outgoing;
    public Option SendTo;
	public Option Parameter;

    private void OnTriggerExit(Collider c)
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
