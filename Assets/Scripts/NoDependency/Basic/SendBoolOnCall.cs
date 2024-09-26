
public class SendBoolOnCall : Base {

    public string Incoming;
	public string Outgoing;
    public string CallSetBool;
    [UnityEngine.Serialization.FormerlySerializedAs("isTrue")]
	public bool IsTrue;
	// Use this for initialization
	void Awake ()
    {
        CacheMethod(Incoming, SendBool);
        CacheMethod(CallSetBool, SetBool);
    }
    void SendBool(object o)
    {
        Call(Outgoing, cachedGameObject,IsTrue);
    }
    void SetBool(object o)
    {
        if (o is bool)
        {
            IsTrue = (bool)o;
        }
    }
	
}
