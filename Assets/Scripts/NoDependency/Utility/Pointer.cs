using UnityEngine;
using System.Collections;

/// <summary>
/// Maybe, not on start, but we can have editor script to replace pointer instead. 
/// </summary>
public class Pointer : MonoBehaviour {
    public GameObject Target;

    private void Awake()
    {
        GameObject go = Instantiate(Target);
        go.name = Target.name;
        go.transform.parent = transform.parent;
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        go.transform.localScale = transform.localScale;
        GameObject.Destroy(gameObject);
    }
}
