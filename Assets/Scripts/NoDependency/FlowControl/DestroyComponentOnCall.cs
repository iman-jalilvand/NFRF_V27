using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponentOnCall : Base
{

    public Component component;
    public string CallDestroy;

    void Start()
    {
        CacheMethod(CallDestroy, (o) =>
        {
            Destroy(component);
        });
    }
}
