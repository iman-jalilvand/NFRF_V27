using UnityEngine;
using System.Collections;

public class SetScriptOnCall : Base {
	public MonoBehaviour Target;
	public string CallSet;

	private void Awake()
	{
        UpdateCachedFields();
		CacheMethod(CallSet, Set);
	}

    private void Set(object o)
    {
        if (o is bool)
        {
            Target.enabled = (bool)o;
        }
    }
}
