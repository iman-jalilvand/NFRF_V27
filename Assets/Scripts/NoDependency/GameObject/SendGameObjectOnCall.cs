using UnityEngine;

public class SendGameObjectOnCall : Base {
    public string CallSend;
	public string CallSetGameObject;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;
    [UnityEngine.Serialization.FormerlySerializedAs("go")]
	public GameObject ReferencedGameObject;


    private void Awake()
    {
        CacheMethod(CallSend, Send);
        CacheMethod(CallSetGameObject, SetGameObject);
    }

    private void Send(object o)
    {
        Call(Outgoing, cachedGameObject, (ReferencedGameObject == null) ? null : ReferencedGameObject);
    }

	private void SetGameObject(object o)
	{
		if(o is Transform) {
			o = ((Transform) o).gameObject;
		}

		ReferencedGameObject = o as GameObject;
	}
}
