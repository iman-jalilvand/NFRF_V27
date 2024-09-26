using UnityEngine;

public class SendAnimationStateInfoOnCall : Base
{
    private int LayerIndex;
    private bool LayerIndexRetrieved;

    public Animator Animator;
    public string Layer;
    public string CallGetInfo;
    public string CallSetAnimator;
    public string Outgoing;


    void Awake()
    {
        CacheMethod(CallGetInfo, GetAnimationStateInfo);
        CacheMethod(CallSetAnimator, SetAnimator);
    }

    void GetAnimationStateInfo(object o)
    {
        if (LayerIndexRetrieved == false)
        {
            if (Animator != null)
            {
                LayerIndex = Animator.GetLayerIndex(Layer);
                LayerIndexRetrieved = true;
            }
        }
        Call(Outgoing, cachedGameObject, Animator.GetCurrentAnimatorStateInfo(LayerIndex));
    }
    void SetAnimator(object o)
    {
		if(o is GameObject) {
			o = ((GameObject)o).GetComponent<Animator>();
		}

		if(o is Transform) {
			o = ((Transform)o).GetComponent<Animator>();
		}

        if (o is Animator)
        {
            Animator = o as Animator;
        }
    }
}
