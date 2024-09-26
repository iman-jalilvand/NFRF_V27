using UnityEngine;
using System.Collections;

public class ParentAnimatorIntInterface : Base
{
   
	public string IntName;

    // make more as you need
    
	public string CallIncrementByOne;
	
	public string CallSet;
	
	public string CallDecrementByOne; // callIncrement callDecrement

    private Animator animator;
    private void Awake()
    {
        UpdateCachedFields();
        animator = cachedTransform.parent.GetComponent<Animator>();

        CacheMethod(CallIncrementByOne, IncrementByOne);
        CacheMethod(CallDecrementByOne, DecrementByOne);
        CacheMethod(CallSet, Set);
    }

    private void IncrementByOne(object o)
    {
        animator.SetInteger(IntName, animator.GetInteger(IntName) + 1);
    }

    private void DecrementByOne(object o)
    {
        animator.SetInteger(IntName, animator.GetInteger(IntName) - 1);
    }

    private void Set(object o)
    {
        if (o is int)
        {
            animator.SetInteger(IntName, (int)o);
        }
    }
}
