using UnityEngine;
using System.Collections;

public class SendGameObjectOnCollisionExit : Base
{
    public string Outgoing;
    public Option SendTo;
    public Option Parameter;

    private void OnCollisionExit(Collision c)
    {
        GameObject target = ExtractGameObject(SendTo, c.collider);
        GameObject parameterGO = ExtractGameObject(Parameter, c.collider);
        Call(Outgoing, target, parameterGO);
    }

    private GameObject ExtractGameObject(Option o, Collider c)
    {
        GameObject result;
        switch (o)
        {
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
