using UnityEngine;
using System.Collections;

public class SendGameObjectToParameter : Base {
	public GameObject Value;

    public string CallSendValueToParam;
    [UnityEngine.Serialization.FormerlySerializedAs("setValue")]
	public string SetValue;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

	private void Awake ()
    {
        UpdateCachedFields();
        CacheMethod(CallSendValueToParam, SendValueToParam);
        CacheMethod(SetValue, SetGameObject);
    }

    void SetGameObject(object o)
    {
        if(o is GameObject)
        {
            Value = (GameObject)o;
        }
    }

	private void SendValueToParam(object o)
	{
		GameObject go = o as GameObject;
		if(go == null) {
			return;
		}

		Call(Outgoing, go, Value);
	}
}
