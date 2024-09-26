using UnityEngine;
using System.Collections;

public class CallOnStart : Base {
    public string methodName;
    public string parameter;
    public Behaviour b;

	void Start () {
	    switch(b)
        {
            case Behaviour.Call:
                Call(methodName, cachedGameObject, parameter);
                break;
            case Behaviour.Broadcast:
                Call(methodName, typeof(Base), parameter);
                break;
        }

	}

    public enum Behaviour
    {
        Call,
        Broadcast
    }
}
