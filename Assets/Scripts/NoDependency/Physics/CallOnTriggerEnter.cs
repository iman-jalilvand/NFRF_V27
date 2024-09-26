using UnityEngine;
using System.Collections;

/// <summary>
/// Exact duplicate of CallOnTrigger, which I wish to make it obsolete.
/// </summary>
public class CallOnTriggerEnter : Base {
    public string Outgoing;
    public Target SendTo;
    private void OnTriggerEnter(Collider c)
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
        Call(Outgoing, target);
    }

    public enum Target
    {
        Self,
        Other
    }
}
