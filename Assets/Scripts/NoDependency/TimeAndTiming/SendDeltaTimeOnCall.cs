using UnityEngine;
using System.Collections;

public class SendDeltaTimeOnCall : Base {

    public string Incoming, Outgoing;
    void Awake()
    {
        CacheMethod(Incoming, Send);
    }
	void Send (object o) {
		Call(Outgoing, cachedGameObject, Time.deltaTime);
	}
}
