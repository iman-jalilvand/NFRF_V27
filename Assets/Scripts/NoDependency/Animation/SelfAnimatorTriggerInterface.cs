using UnityEngine;
using System.Collections;

public class SelfAnimatorTriggerInterface  : Base {
	private Animator animator;
	[UnityEngine.Serialization.FormerlySerializedAs("triggerName")]
	public string TriggerName;
	[UnityEngine.Serialization.FormerlySerializedAs("callTrigger")]
	public string CallTrigger;
	[UnityEngine.Serialization.FormerlySerializedAs("callReset")]
	public string CallReset;

	private void Awake()
	{
        UpdateCachedFields();
        animator = cachedTransform.GetComponent<Animator>();
		CacheMethod(CallTrigger, Trigger);
		CacheMethod(CallReset, ResetTrigger);
	}

	private void Trigger(object o)
	{
		if(TriggerName != null && animator != null) {
			animator.SetTrigger(TriggerName);
		}
	}

	private void ResetTrigger(object o)
	{
		animator.ResetTrigger(TriggerName);
	}
}
