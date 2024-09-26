using UnityEngine;
using System.Collections;

public class SetActiveSelfAnimatorOnCall : Base {

    public string CallEnableAnimator;
    public string CallDisableAnimator;
    public string CallSetAnimator;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = cachedGameObject.GetComponent<Animator>();
        CacheMethod(CallEnableAnimator, EnableAnimator);
        CacheMethod(CallDisableAnimator, DisableAnimator);
        CacheMethod(CallSetAnimator, SetActive);
    }

    void EnableAnimator(object o)
    {
        SetActive(true);
    }
    void DisableAnimator(object o)
    {
        SetActive(false);
    }
    void SetActive(object o)
    {
		bool b;
		if(o is bool) {
			animator.enabled = (bool)o;
		} else if(o != null && bool.TryParse(o.ToString(), out b))
        {
            animator.enabled = b;
        }
    }
}
