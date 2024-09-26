using UnityEngine;
using System.Collections;

public class SelfAnimatorBooleanInterface : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("boolName")]
	public string BoolName;
    [UnityEngine.Serialization.FormerlySerializedAs("callFlip")]
	public string CallFlip;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetTrue")]
	public string CallSetTrue;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetFalse")]
	public string CallSetFalse;
	[UnityEngine.Serialization.FormerlySerializedAs("callSet")]
	public string CallSet;
    private Animator animator;

    private void Awake()
    {
		UpdateCachedFields();
		animator = cachedTransform.GetComponent<Animator>();
        CacheMethod(CallFlip, Flip);
        CacheMethod(CallSetTrue, SetTrue);
        CacheMethod(CallSetFalse, SetFalse);
        CacheMethod(CallSet, Set);
    }

    private void Flip(object o)
    {
        animator.SetBool(BoolName, animator.GetBool(BoolName));
    }

    private void SetTrue(object o)
    {
        animator.SetBool(BoolName, true);
    }

    private void SetFalse(object o)
    {
        animator.SetBool(BoolName, false);
    }

    private void Set(object o)
    {
        if(o is bool)
        {
            animator.SetBool(BoolName, (bool)o);
        }
    }
}