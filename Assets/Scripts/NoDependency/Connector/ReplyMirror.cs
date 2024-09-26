using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReplyMirror : Base
{
    public string Incoming;
    public string Outgoing;
    public string IncomingReply;
	public string OutgoingReply;

    public string CallSetIncomingReply;
    public string CallSetOutgoingReply;

    public GameObject Target;

	private void Awake()
    {
        CacheMethod(Incoming, StoreReply);
        CacheMethod(IncomingReply, Reply);
        CacheMethod(CallSetIncomingReply, SetIncomingReply);
        CacheMethod(CallSetOutgoingReply, SetOutgoingReply);
    }
    private void SetIncomingReply(object o)
    {
        IncomingReply = o.ToString();
    }
    private void SetOutgoingReply(object o)
    {
        OutgoingReply = o.ToString();
    }

    private void Reply(object o)
    {
        Call(OutgoingReply, Target, o);
    }
    private void StoreReply(object o)
    {
        KeyValuePair<Type, object> pair = CallStack.Peek();
        if (pair.Key.IsSubclassOf(typeof(Base)) || pair.Equals(typeof(Base)))
        {
            StoreBase((Base)pair.Value);
        }
        else if (pair.Key.IsSubclassOf(typeof(MonoBehaviour)) || pair.Equals(typeof(MonoBehaviour)))
        {
            StoreMonoBehaviour((MonoBehaviour)pair.Value);
        }
        else if (pair.Key.IsSubclassOf(typeof(MonoBehaviour)) || pair.Equals(typeof(MonoBehaviour)))
        {
            StoreGameObject((GameObject)pair.Value);
        }
        Call(Outgoing, cachedGameObject, o);
    }

    private void StoreBase(Base b)
	{
        Target = GetCachedGameObject(b);
	}

	private void StoreGameObject(GameObject go)
    {
        Target = go;
    }

	private void StoreMonoBehaviour(MonoBehaviour mono)
    {
        Target = mono.gameObject;
    }
}
