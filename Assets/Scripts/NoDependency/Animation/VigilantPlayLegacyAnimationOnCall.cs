using UnityEngine;
using System.Collections;

public class VigilantPlayLegacyAnimationOnCall : Base {
	public Animation anim;
	public string animationName;
	public string Incoming;

	private void Awake()
	{
		base.OnEnable();
		CacheMethod(Incoming, (o)=> {
			anim.Play(animationName);
		});
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}

	protected override void OnEnable()
	{
		//
	}

	protected override void OnDisable()
	{
		//
	}
}
