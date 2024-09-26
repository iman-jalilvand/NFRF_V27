using UnityEngine;
using System.Collections;

public class SetActiveSelfOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("callEnable")]
	public string CallEnable;
	[UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
	public string CallDisable;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetActive")]
	public string CallSetActive;

    private GameObject target;
    private void Awake()
    {
        UpdateCachedFields();
        target = cachedGameObject;
        CacheMethod(CallEnable, Enable);
        CacheMethod(CallDisable, Disable);
        CacheMethod(CallSetActive, SetActive);
    }

    private void Enable(object o)
    {
        if (target == null)
        {
            return;
        }
        target.SetActive(true);
    }

    private void Disable(object o)
    {
        if (target == null)
        {
            return;
        }
        target.SetActive(false);
    }

    private void SetActive(object o)
    {
        if (target == null)
        {
            return;
        }
        if (o is string)
        {
            o = bool.Parse((string)o);
        }

        if (o is bool)
        {
            target.SetActive((bool)o);
        }

    }
}
