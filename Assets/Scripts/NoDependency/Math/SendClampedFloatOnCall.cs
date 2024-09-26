using UnityEngine;

public class SendClampedFloatOnCall : Base
{

    public string Incoming;
    public string Outgoing;
    public float Min;
    public float Max;

    void Awake()
    {
        CacheMethod(Incoming, SendClamp);
    }
    void SendClamp(object o)
    {
        float f;
		if(o is float) {
			f = (float)o;

            Call(Outgoing, cachedGameObject, Mathf.Clamp(f, Min, Max));
		} else if (float.TryParse(o.ToString(), out f))
        {
            Call(Outgoing, cachedGameObject, Mathf.Clamp(f, Min, Max));
        }
    }
}
