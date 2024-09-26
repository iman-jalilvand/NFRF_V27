using UnityEngine;
using System.Collections;

/// <summary>
/// Unlike CallOnDelay, this one actually passes parameters. 
/// </summary>
public class TranslateAfterFrameDelayOnCall : Base {
    public string Incoming;
    public string Outgoing;
	public int Delay = 1;

    public Behaviour SendTo;

	private void Awake()
	{
		CacheMethod(Incoming, DelayedCall);
	}

    private void DelayedCall(object o)
    {
        switch(SendTo)
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
		for(int i = 0; i < Delay; ++i) {
			yield return null;
		}
		Call(Outgoing, typeof(Base), o);
	}

	private IEnumerator Self(object o)
	{
		for(int i = 0; i < Delay; ++i) {
			yield return null;
		}
		Call(Outgoing, cachedGameObject, o);
	}

    public enum Behaviour
    {
        Self,
        All
    }

}
