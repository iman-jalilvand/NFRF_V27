using UnityEngine;
using System.Collections;

public class SetParentOnCall : Base
{
	public string Incoming;

	void Awake()
	{
		CacheMethod(Incoming, SetParent);
	}

	private void SetParent(object o)
	{
		if (o is GameObject)
		{
			o = ((GameObject)o).transform;
		}

		if (o is Transform)
		{
			cachedTransform.SetParent((Transform)o);
		}
        if(o == null)
        {
            transform.SetParent(null);
        }
	}
}
