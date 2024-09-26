using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendFloatOnTriggerEnter : Base {
    public string Outgoing;
	public float Value;
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
        Call(Outgoing, target, Value);
    }

    public enum Target
    {
        Self,
        Other
    }
}
