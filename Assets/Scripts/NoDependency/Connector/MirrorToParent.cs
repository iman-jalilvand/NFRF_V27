
public class MirrorToParent : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("msg")]
	public string MirroredMessage;

    private void Awake()
    {
        CacheMethod(MirroredMessage, (o) =>
        {
            Call(MirroredMessage, cachedTransform.parent.gameObject, o);
        });
    }
}
