using UnityEngine;
using System.Collections;

public class AnimatorIntInterface : Base {
    public Animator Animator;
    public string IntName;

	// make more as you need
	public string CallIncrementByOne;
	public string CallSet;
	public string CallDecrementByOne; // callIncrement callDecrement

    private void Awake()
    {
        CacheMethod(CallIncrementByOne, IncrementByOne);
        CacheMethod(CallDecrementByOne, DecrementByOne);
        CacheMethod(CallSet, Set);
    }

	private void IncrementByOne(object o)
	{
		Animator.SetInteger(IntName, Animator.GetInteger(IntName) + 1);
	}

	private void DecrementByOne(object o)
	{
		Animator.SetInteger(IntName, Animator.GetInteger(IntName) - 1);
	}

    private void Set(object o)
    {
		int i;
		if(o is int) {
            Animator.SetInteger(IntName, (int) o);
		} else if(int.TryParse(o.ToString(), out i))
        {
            Animator.SetInteger(IntName, i);
        }
    }
}
