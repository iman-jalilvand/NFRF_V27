using UnityEngine;
using System.Collections;

public class ParentAnimatorFloatInterface : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("floatName")]
	public string floatName;

	// make more as you need
    [UnityEngine.Serialization.FormerlySerializedAs("callIncrementByOne")]
	public string CallIncrementByOne;
	[UnityEngine.Serialization.FormerlySerializedAs("callSet")]
	public string CallSet;
	[UnityEngine.Serialization.FormerlySerializedAs("callDecrementByOne")]
	public string CallDecrementByOne;
	[UnityEngine.Serialization.FormerlySerializedAs("callIncrement")]
	public string CallIncrement;
	[UnityEngine.Serialization.FormerlySerializedAs("callDecrement")]
	public string CallDecrement;

	public float Min = float.MinValue;
	public float Max = float.MaxValue;

    private Animator animator;

    private void Awake()
    {
        UpdateCachedFields();
        animator = cachedTransform.parent.GetComponent<Animator>();
        CacheMethod(CallIncrementByOne, IncrementByOne);
        CacheMethod(CallDecrementByOne, DecrementByOne);
		CacheMethod(CallIncrement, Increment);
		CacheMethod(CallDecrement, Decrement);
        CacheMethod(CallSet, Set);
    }

	private void IncrementByOne(object o)
	{
		animator.SetFloat(floatName, animator.GetInteger(floatName) + 1);
	}

	private void DecrementByOne(object o)
	{
		animator.SetFloat(floatName, animator.GetInteger(floatName) - 1);
	}

	private void Increment(object o)
	{
        if(o is float)
        {
			float f = (float) o;
			f = animator.GetFloat(floatName) + f;
			f = Mathf.Clamp(f, Min, Max);
            animator.SetFloat(floatName, f);
        }
	}

	private void Decrement(object o) {
        if(o is float)
        {
			float f = (float) o;
			f = animator.GetFloat(floatName) - f;
			f = Mathf.Clamp(f, Min, Max);
            animator.SetFloat(floatName, f);
        }
	}


    private void Set(object o)
    {
        if(o is float)
        {
            animator.SetFloat(floatName, (float)o);
        }
    }
}
