using UnityEngine;
using System.Collections;

public class CallOnUpdate : Base {
    public string Outgoing;
    public Behaviour SendTo;

	void Update () {
	    switch(SendTo)
        {
            case Behaviour.Self:
                Call(Outgoing, cachedGameObject);
                break;
            case Behaviour.All:
                Call(Outgoing, typeof(Base));
                break;
        }
	}
    public enum Behaviour
    {
        Self,
        All
    }
}
