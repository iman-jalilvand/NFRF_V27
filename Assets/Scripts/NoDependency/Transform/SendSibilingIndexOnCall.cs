using UnityEngine;
using System.Collections;

public class SendSibilingIndexOnCall : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("callSendSiblingIndex")]
	public string Incoming;
    [UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Outgoing;

    private void Awake()
    {
        CacheMethod(Incoming, SendSiblingIndex);
    }

    private void SendSiblingIndex(object o)
    {
        Call(Outgoing, cachedGameObject, cachedTransform.GetSiblingIndex());
    }
}
