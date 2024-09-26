using UnityEngine;
using System.Collections;

public class SendAnimatorDeltaRotationOnCall : Base {

    public string Incoming, Outgoing;
    public Animator animator;

    public void Awake()
    {
        CacheMethod(Incoming, Send);
    }
    void Send(object o)
    {
        Call(Outgoing,cachedGameObject,animator.deltaRotation);
    }
}
