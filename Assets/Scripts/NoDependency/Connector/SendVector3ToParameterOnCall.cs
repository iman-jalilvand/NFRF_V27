using UnityEngine;
using System.Collections;

public class SendVector3ToParameterOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("value")]
	public Vector3 Value;

    public string CallSendValueToParam;
    [UnityEngine.Serialization.FormerlySerializedAs("setValue")]
	public string SetValue;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;

	private void Start ()
    {
        CacheMethod(CallSendValueToParam, SendValueToParam);
        CacheMethod(SetValue, SetGameObject);
    }
    void SetGameObject(object o)
    {
        if(o is Vector3)
        {
            Value = (Vector3)o;
        }
    }
	private void SendValueToParam(object o)
	{
		if(o is Transform) {
			o = ((Transform)o).gameObject;
		}

		GameObject go = o as GameObject;
		if(go == null) {
			return;
		}

		Call(Outgoing, go, Value);
	}
}
