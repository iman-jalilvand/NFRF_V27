using UnityEngine;
using System.Collections;

public class SendCurrentAnimationStateOnCall : Base {
    public string Incoming, Outgoing;
    public string CallSetAnimator, CallSetLayer;
    public Animator animator;
    public int Layer;
    void Awake()
    {
        CacheMethod(Incoming, Send);
        CacheMethod(CallSetAnimator, SetAnimator);
        CacheMethod(CallSetLayer, SetLayer);
    }
    void Send(object o)
    {
        if (animator)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(Layer);
            Call(Outgoing, cachedGameObject, stateInfo.shortNameHash);
        }
    }
    void SetAnimator(object o)
    {
        if (o is Animator)
        {
            animator = (Animator)o;
        }
    }
    void SetLayer(object o)
    {
        if (o is int)
        {
            Layer = (int)o;
        }
    }
}
