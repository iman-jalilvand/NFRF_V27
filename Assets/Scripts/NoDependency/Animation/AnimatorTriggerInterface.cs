using UnityEngine;
using System.Collections;

public class AnimatorTriggerInterface : Base {
	public Animator Animator;
	public string TriggerName;
	public string CallTrigger;
	public string CallReset;

	private void Awake()
	{
		CacheMethod(CallTrigger, Trigger);
		CacheMethod(CallReset, ResetTrigger);
	}

    public void Trigger()
    {
		Trigger(null);
    }

    private void Trigger(object o)
	{
		if(TriggerName != null && Animator != null) {
			Animator.SetTrigger(TriggerName);
		}
	}

	private void ResetTrigger(object o)
	{
		if(Animator == null) {
			print(TriggerName + " from " + name);
			return;
		}
		Animator.ResetTrigger(TriggerName);
	}
}
