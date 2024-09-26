using UnityEngine;
using System.Collections;

public class EnableGameObjectsOnCall : Base {
	public GameObject[] Targets;
    public string CallSetTarget;
	public string CallEnable;

	private void Awake()
    {
        CacheMethod(CallEnable, Enable);
        CacheMethod(CallSetTarget, SetTarget);
    }
    private void SetTarget(object o)
    {
        if(o is GameObject[])
        {
            Targets = (GameObject[])o;
        }
    }
	private void Enable(object o)
	{
        if (Targets != null)
        {
            for (int i = 0, c = Targets.Length; i < c; ++i)
            {
                Targets[i].SetActive(true);
            }
        }
	}
}
