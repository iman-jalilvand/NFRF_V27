using UnityEngine;
using System.Collections;

public class GateMirror : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("open")]
	public bool Open;
    [UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;
	[UnityEngine.Serialization.FormerlySerializedAs("callCloseGate")]
	public string CallCloseGate;
	[UnityEngine.Serialization.FormerlySerializedAs("callOpenGate")]
	public string CallOpenGate;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetTarget")]
	public string CallSetTarget;
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public GameObject Target;

    private void Awake()
    {
        CacheMethod(Incoming, IncomingMethod);
        CacheMethod(CallCloseGate, CloseGate);
        CacheMethod(CallOpenGate, OpenGate);
		CacheMethod(CallSetTarget, SetTarget);
	}

	private void CloseGate(object o) {
		Open = false;
	}

	private void OpenGate(object o) {
		Open = true;
	}

    private void IncomingMethod(object o)
    {
		if(Open) {
			if(Target == null) {
				return;
			}
			Call(Outgoing, Target, o);
		}
    }


	private void SetTarget(object o) {
		Target = o as GameObject;
	}
}
