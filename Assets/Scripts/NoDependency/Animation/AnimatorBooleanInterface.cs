using UnityEngine;
using System.Collections;

public class AnimatorBooleanInterface : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("animator")]
	public Animator Animator;
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

    private void Awake()
    {
        CacheMethod(CallFlip, Flip);
        CacheMethod(CallSetTrue, SetTrue);
        CacheMethod(CallSetFalse, SetFalse);
        CacheMethod(CallSet, Set);
    }

    private void Flip(object o)
    {
        Animator.SetBool(BoolName, Animator.GetBool(BoolName));
    }

    private void SetTrue(object o)
    {
        Animator.SetBool(BoolName, true);
    }

    private void SetFalse(object o)
    {
        Animator.SetBool(BoolName, false);
    }

    private void Set(object o)
    {
        if(o is bool)
        {
            Animator.SetBool(BoolName, (bool)o);
        }
    }
}
