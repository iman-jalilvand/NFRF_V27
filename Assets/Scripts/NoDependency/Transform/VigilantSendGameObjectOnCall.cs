using UnityEngine;

public class VigilantSendGameObjectOnCall : Base {
	public string CallSend;
	public string CallSetGameObject;
	
	public string Outgoing;
	
	public GameObject SentGameObject;

	private void Awake()
	{
		base.OnEnable();

		CacheMethod(CallSend, Send);
		CacheMethod(CallSetGameObject, SetGameObject);
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}

	protected override void OnEnable()
	{
		//
	}

	protected override void OnDisable()
	{
		//
	}

	private void Send(object o)
	{
		Call(Outgoing, cachedGameObject, SentGameObject == null ? null : SentGameObject);
	}

	private void SetGameObject(object o)
	{
		SentGameObject = o as GameObject;
	}
}
