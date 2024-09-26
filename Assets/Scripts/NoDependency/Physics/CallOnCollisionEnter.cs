using UnityEngine;
using System.Collections;

public class CallOnCollisionEnter : Base {
    public string Outgoing;
    public string Parameter;
    public Target SendTo;
    private void OnCollisionEnter(Collision c)
    {
        GameObject target;
        switch(SendTo)
        {
            case Target.Self:
                target = cachedGameObject;
                break;
            case Target.Other:
            default:
                target = c.gameObject;
                break;
        }
        Call(Outgoing, target, Parameter);
    }

    public enum Target
    {
        Self,
        Other
    }
}
