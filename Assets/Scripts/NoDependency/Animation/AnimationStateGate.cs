using UnityEngine;
using System.Collections;

public class AnimationStateGate : Base {
    public string Incoming, Outgoing;
    public string CallSetAnimator, CallSetLayer, CallSetStateName;
    public Animator animator;
    public int Layer;
    public string StateName;
    public bool SendIfTrue = true;
    void Awake()
    {
        CacheMethod(Incoming, Send);
        CacheMethod(CallSetAnimator, SetAnimator);
        CacheMethod(CallSetLayer, SetLayer);
        CacheMethod(CallSetStateName, SetStateName);
    }
    void Send(object o)
    {
        if (animator)
        {
            bool nextIsName = false;
            if (animator.IsInTransition(Layer))
            {
                AnimatorStateInfo nextStateInfo = animator.GetNextAnimatorStateInfo(Layer);
                nextIsName = nextStateInfo.IsName(StateName);


                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(Layer);
                if (SendIfTrue && nextIsName)
                {
                    Call(Outgoing, cachedGameObject, o);
                }
                else if (!SendIfTrue && !nextIsName)
                {
                    Call(Outgoing, cachedGameObject, o);
                }
            }
            else
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(Layer);
                if (SendIfTrue && stateInfo.IsName(StateName))
                {
                    Call(Outgoing, cachedGameObject, o);
                }
                else if (!SendIfTrue && !stateInfo.IsName(StateName))
                {
                    Call(Outgoing, cachedGameObject, o);
                }
            }
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
    void SetStateName(object o)
    {
        if (o is string)
        {
            StateName = (string)o;
        }
    }
}
