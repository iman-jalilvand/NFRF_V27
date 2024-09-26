using UnityEngine;
using System.Collections;

public class CallOnLateUpdate : Base {
    public string Outgoing;
    public Behaviour SendTo;

	void LateUpdate () {
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
