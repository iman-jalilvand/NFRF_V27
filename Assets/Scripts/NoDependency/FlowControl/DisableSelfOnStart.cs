using UnityEngine;
using System.Collections;

public class DisableSelfOnStart : Base {
    private void Start()
    {
        cachedGameObject.SetActive(false);
    }
}
