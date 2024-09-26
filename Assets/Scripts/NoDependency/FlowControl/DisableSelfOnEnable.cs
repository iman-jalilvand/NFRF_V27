using UnityEngine;
using System.Collections;

public class DisableSelfOnEnable : Base {
    protected override void OnEnable()
    {
        base.OnEnable();
        cachedGameObject.SetActive(false);
    }
}
