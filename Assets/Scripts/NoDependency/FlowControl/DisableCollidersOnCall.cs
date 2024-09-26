using UnityEngine;
using System.Collections;

public class DisableCollidersOnCall : Base
{
    public Collider[] Targets;
    public string CallDisable;

    private void Start()
    {
        CacheMethod(CallDisable, Disable);
    }

    private void Disable(object o)
    {
        for (int i = 0, max = Targets.Length; i < max; ++i)
        {
            if (Targets[i])
            {
                Targets[i].enabled = false;
            }
        }
    }
}
