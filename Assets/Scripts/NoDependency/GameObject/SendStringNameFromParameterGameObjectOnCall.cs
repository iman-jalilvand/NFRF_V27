using UnityEngine;

public class SendStringNameFromParameterGameObjectOnCall : Base
{
    public string Incoming;

    public string Outgoing;

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
            if (o != null && o is GameObject)
            {
                Call(Outgoing, cachedGameObject, ((GameObject)o).name);
            }
        });
    }
}
