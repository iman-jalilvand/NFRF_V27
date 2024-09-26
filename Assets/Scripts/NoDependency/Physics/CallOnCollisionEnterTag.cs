using UnityEngine;

public class CallOnCollisionEnterTag : Base
{
    public string Outgoing;
    public string FilterTag;
    public string Parameter;
    public Target SendTo;
    private void OnCollisionEnter(Collision c)
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
