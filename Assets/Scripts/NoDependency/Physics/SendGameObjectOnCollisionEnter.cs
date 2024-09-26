using UnityEngine;
using System.Collections;

public class SendGameObjectOnCollisionEnter : Base
{
    public string methodName;
    public Option sendTo, parameter;

    private void OnCollisionEnter(Collision c)
    {
        GameObject target = ExtractGameObject(sendTo, c.collider);
        GameObject parameterGO = ExtractGameObject(parameter, c.collider);
        Call(methodName, target, parameterGO);
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
