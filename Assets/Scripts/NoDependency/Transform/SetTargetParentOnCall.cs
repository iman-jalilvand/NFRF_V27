using UnityEngine;

public class SetTargetParentOnCall : Base
{
	public Transform Target;
	public string CallSetParent;
	public string CallSetTarget;
	
	void Awake()
	{
		CacheMethod(CallSetParent, SetParent);
		CacheMethod(CallSetTarget, SetTarget);
	}
    private void SetTarget(object o)
    {
		if (o is GameObject)
		{
			o = ((GameObject)o).transform;
		}

        if(o is Transform)
        {
            Target = (Transform)o;
        }
    }
	private void SetParent(object o)
	{
		if (o is GameObject)
		{
			o = ((GameObject)o).transform;
		}

		if (o is Transform)
		{
            Target.SetParent((Transform)o);
		}
	}
}
