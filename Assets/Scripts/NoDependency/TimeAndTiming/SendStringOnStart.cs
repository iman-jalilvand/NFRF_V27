using UnityEngine;
using System.Collections;

public class SendStringOnStart : Base
{
    public string Outgoing;
    public string Parameter;
    public Behaviour SendTo;

    void Start()
    {
        switch (SendTo)
        {
            case Behaviour.Self:
                Call(Outgoing, cachedGameObject, Parameter);
                break;
            case Behaviour.All:
                Call(Outgoing, typeof(Base), Parameter);
                break;
        }

    }

    public enum Behaviour
    {
        Self,
        All
    }
}
