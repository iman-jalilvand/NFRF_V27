using UnityEngine;
using System.Collections;

public class SetTargetIsKinematicOnCall : Base {
	public string Incoming;

	public Rigidbody Target;

    void Start()
    {
        CacheMethod(Incoming,SetIsKinematic);
    }

    void SetIsKinematic(object o)
    {
        if(o is bool)
        {
            Target.isKinematic = (bool)o;
        }
    }
}
