using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimatorOnCall : Base
{

    public Animator anim;
    public string CallDisable;

    void Start()
    {
        CacheMethod(CallDisable, (o) =>
        {
            anim.enabled = false;
        });
    }
}
