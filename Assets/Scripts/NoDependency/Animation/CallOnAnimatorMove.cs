using UnityEngine;
using System.Collections;

public class CallOnAnimatorMove : Base {
    public string Outgoing;
    public Behaviour SendTo;

	void OnAnimatorMove() {
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
