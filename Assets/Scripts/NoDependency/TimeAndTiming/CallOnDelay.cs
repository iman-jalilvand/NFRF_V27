using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Sadly because how invoke works, 
/// doesn't pass parameter. 
/// Thought of a way to do with queue, but found that is not too reliable. 
/// Doing it in update is a way as well, but decided to go with invoke. 
/// </summary>
public class CallOnDelay : Base 
{
    public string CallDelayedCall;
    public string Outgoing;
	public float Delay = 0f;
	public bool IgnoreInvokeIfDisabled = true;
    public Behaviour SendTo;

	private void Awake()
	{
		CacheMethod(CallDelayedCall, DelayedCall);
	}

    private void DelayedCall(object o)
    {
        switch(SendTo)
        {
            case Behaviour.All:
				Invoke("All", Delay);
                break;
            case Behaviour.Self:
				Invoke("Self", Delay);
                break;
        }
    }

	private void All()
	{
		if(IgnoreInvokeIfDisabled && !isActiveAndEnabled) {
			return;
		}
		Call(Outgoing, typeof(Base));
	}

	private void Self()
	{
		if(IgnoreInvokeIfDisabled && !isActiveAndEnabled) {
			return;
		}
		Call(Outgoing, cachedGameObject);
	}



    public enum Behaviour
    {
        Self,
        All
    }
}
