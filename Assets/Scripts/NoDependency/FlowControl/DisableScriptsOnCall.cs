using UnityEngine;

public class DisableScriptsOnCall : Base
{
    public MonoBehaviour[] Targets;
    public string CallDisable;

    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(CallDisable, Disable);
    }

    private void Disable(object o)
    {
        for (int i = 0, max = Targets.Length; i < max; ++i)
        {
			Targets[i].enabled = false;
        }
    }
}
