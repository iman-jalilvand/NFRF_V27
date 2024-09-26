using UnityEngine;
using System.Collections;

public class VigilantSetAnimationNormalizedTimeOnCall : Base {
	public string Incoming;
	public Animation anim;
	public string animationName;

	private void Awake()
	{
		base.OnEnable();
		CacheMethod(Incoming, SetAnimationNormaliedTime);
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

	private void SetAnimationNormaliedTime(object o)
	{
		float normalizedTime;
		if(o is float) {
			anim[animationName].normalizedTime = (float)o;
			anim[animationName].normalizedSpeed = 0;
		} else if(float.TryParse(o.ToString(), out normalizedTime)) {
			anim[animationName].normalizedTime = normalizedTime;
			anim[animationName].normalizedSpeed = 0;
		}
	}
}
