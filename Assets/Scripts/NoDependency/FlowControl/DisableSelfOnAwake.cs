using UnityEngine;
using System.Collections;

public class DisableSelfOnAwake : Base {
    void Awake()
    {
		UpdateCachedFields();
        cachedGameObject.SetActive(false);
    }
}
