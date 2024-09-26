
public class Translator : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("incoming")]
    public string Incoming;
    [UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
    public string Outgoing;

    public string CallSetIncoming;
    public string CallSetOugoing;

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
            Call(Outgoing, cachedGameObject, o);
        });
        CacheMethod(CallSetIncoming, (o) =>
        {
            Incoming = o.ToString();
            base.OnDisable();
            base.OnEnable();
        });
        CacheMethod(CallSetOugoing, (o) =>
        {
            Outgoing = o.ToString();
        });
    }
}
