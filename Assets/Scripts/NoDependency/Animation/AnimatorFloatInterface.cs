using UnityEngine;
using System.Collections;

public class AnimatorFloatInterface : Base
{
	public Animator Animator;
	public string FloatName;

	// make more as you need
	public string CallIncrementByOne;
	public string CallSet;
	public string CallSetAnimator;
	public string CallGet;
	public string CallDecrementByOne;
	public string CallIncrement;
	public string CallDecrement;

	public string Outgoing;

	public float Min = float.MinValue;
	public float Max = float.MaxValue;

	private void Awake()
	{
		CacheMethod(CallIncrementByOne, IncrementByOne);
		CacheMethod(CallDecrementByOne, DecrementByOne);
		CacheMethod(CallIncrement, Increment);
		CacheMethod(CallDecrement, Decrement);
		CacheMethod(CallSet, Set);
		CacheMethod(CallSetAnimator, SetAnimator);
		CacheMethod(CallGet, Get);
	}

	private void IncrementByOne(object o)
	{
		Animator.SetFloat(FloatName, Animator.GetInteger(FloatName) + 1);
	}

	private void DecrementByOne(object o)
	{
		Animator.SetFloat(FloatName, Animator.GetInteger(FloatName) - 1);
	}

	private void Increment(object o)
	{
		float f;

		if(o is float) {
			f = (float) o;
			f = Animator.GetFloat(FloatName) + f;
			f = Mathf.Clamp(f, Min, Max);
			Animator.SetFloat(FloatName, f);
		} else if (float.TryParse(o.ToString(), out f))
		{
			f = Animator.GetFloat(FloatName) + f;
			f = Mathf.Clamp(f, Min, Max);
			Animator.SetFloat(FloatName, f);
		}
	}

	private void Decrement(object o)
	{
		float f;
		if(o is float) {
			f = (float)o;
			f = Animator.GetFloat(FloatName) - f;
			f = Mathf.Clamp(f, Min, Max);
			Animator.SetFloat(FloatName, f);
		} else if (float.TryParse(o.ToString(), out f))
		{
			f = Animator.GetFloat(FloatName) - f;
			f = Mathf.Clamp(f, Min, Max);
			Animator.SetFloat(FloatName, f);
		}
	}


	private void Set(object o)
	{
		float f;
		if(o is float) {
			Animator.SetFloat(FloatName, (float)o);
		} else if (float.TryParse(o.ToString(), out f))
		{
			Animator.SetFloat(FloatName, f);
		}
	}

	private void SetAnimator(object o)
	{
		Animator animator;

		if(o is Transform) {
			o = ((Transform)o).GetComponent<Animator>();
		}

		if(o is GameObject) {
			o = ((GameObject)o).GetComponent<Animator>();
		}

		animator = o as Animator;

		Animator = animator;
	}

	private void Get(object o)
	{
		if(Animator == null) {
			return;
		}
		float f = Animator.GetFloat(FloatName);
		Call(Outgoing, cachedGameObject, f);
	}
}
