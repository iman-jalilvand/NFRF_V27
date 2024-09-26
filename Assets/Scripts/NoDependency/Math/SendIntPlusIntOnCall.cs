using UnityEngine;
using System.Collections;

public class SendIntPlusIntOnCall : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("callSendIntPlusInt")]
	public string CallSendIntPlusInt;
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Incoming;
	public string Outgoing;
    [UnityEngine.Serialization.FormerlySerializedAs("value")]
	public int Value;

    private void Awake()
    {
        CacheMethod(CallSendIntPlusInt, SendIntPlusInt);
    }

    private void SendIntPlusInt(object o)
    {
        int i;
		if(o is int) {
			i = (int)o;
            Call(Outgoing, cachedGameObject, i + Value);
		} else if(o != null && int.TryParse(o.ToString(), out i))
        {
            Call(Outgoing, cachedGameObject, i + Value);
        }
    }
}
