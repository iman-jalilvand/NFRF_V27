using UnityEngine;

public class CallOnTriggerEnterTag : Base
{
    public string Outgoing;
    public string FilterTag;
    public string Parameter;
    public Target SendTo;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag(FilterTag))
        {
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
            Call(Outgoing, target, Parameter);
        }
    }

    public enum Target
    {
        Self,
        Other
    }
}
