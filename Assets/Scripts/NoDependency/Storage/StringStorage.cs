using UnityEngine;

public class StringStorage : Base
{
    public string CallSet;
    public string CallGet;

    [SpaceAttribute(5)]
    [UnityEngine.Serialization.FormerlySerializedAs("OnStringChanged")]
	public string OutgoingOnStringChanged;
    [UnityEngine.Serialization.FormerlySerializedAs("OnGet")]
	public string OutgoingOnGet;

    [SpaceAttribute(1)]
    [HeaderAttribute("Stored value")]
    [UnityEngine.Serialization.FormerlySerializedAs("_value")]
	public string StoredValue;
    public string Value
    {
        get
        {
            return StoredValue;
        }
        set
        {
            StoredValue = value;
            Call(OutgoingOnStringChanged, cachedGameObject, StoredValue);
        }
    }

    void Start()
    {
        CacheMethod(CallSet, Set);
        CacheMethod(CallGet, Get);
    }

    private void Set(object o)
    {
		if(o is string) {
			Value = (string)o;
		} else {
			Value = o.ToString();
		}
    }

    private void Get(object o)
    {
        Call(OutgoingOnGet, cachedGameObject, Value);
    }
}
