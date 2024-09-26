using UnityEngine;
using System.Collections;

public class DisableSelfGameObjectOnCall : Base {
    public string CallDisable;
    private void Awake()
    {
        CacheMethod(CallDisable,Disable);
    }
    private void Disable(object o)
    {
        cachedGameObject.SetActive(false);
    }
}
