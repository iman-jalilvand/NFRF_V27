using UnityEngine;

public class SendAnimatorOnCall : Base {
    public string CallSend;
	public string CallSetGameObject;
	public string Outgoing;
	public Animator ReferencedGameObject;


    private void Awake()
    {
        CacheMethod(CallSend, Send);
        CacheMethod(CallSetGameObject, SetAnimator);
    }

    private void Send(object o)
    {
        Call(Outgoing, cachedGameObject, (ReferencedGameObject == null) ? null : ReferencedGameObject);
    }

	private void SetAnimator(object o)
	{
		ReferencedGameObject = o as Animator;
	}
}
