using UnityEngine;
using System.Collections;

public class CallOnTriggerStay : Base {
    public string Outoing;
    public string Parameter;
    public Target SendTo;
    private void OnTriggerStay(Collider c)
    {
        Debug.Log(c.gameObject);
        GameObject target;
        switch (SendTo)
        {
            case Target.Self:
                target = cachedGameObject;
                break;
            case Target.Other:
            default:
                target = c.gameObject;
                break;
        }
        Call(Outoing, target, Parameter);
    }

    public enum Target
    {
        Self,
        Other
    }
}
