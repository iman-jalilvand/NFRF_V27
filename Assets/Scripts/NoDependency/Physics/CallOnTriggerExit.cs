using UnityEngine;
using System.Collections;

public class CallOnTriggerExit : Base {
    public string Outgoing;
    public Target SendTo;

    private void OnTriggerExit(Collider c)
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