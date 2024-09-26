using UnityEngine;
using System.Collections;

/// <summary>
/// Unlike CallOnDelay, this one actually passes parameters. 
/// </summary>
public class CallOnFrameDelay : Base {
    public string callDelayedCall;
    public string methodName;
	public int delay = 1;

    public Behaviour sendTo;

	private void Awake()
	{
		CacheMethod(callDelayedCall, DelayedCall);
	}

    private void DelayedCall(object o)
    {
        switch(sendTo)
        {
            case Behaviour.All:
				StartCoroutine(All(o));
                break;
            case Behaviour.Self:
				StartCoroutine(Self(o));
                break;
        }
    }

	private IEnumerator All(object o)
	{
		for(int i = 0; i < delay; ++i) {
			yield return null;
		}
		Call(methodName, typeof(Base), o);
	}

	private IEnumerator Self(object o)
	{
		for(int i = 0; i < delay; ++i) {
			yield return null;
		}
		Call(methodName, cachedGameObject, o);
	}



    public enum Behaviour
    {
        Self,
        All
    }

}
