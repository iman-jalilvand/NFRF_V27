using UnityEngine;
using System.Collections;

public class SendIntPlusIntAfterDelayOnCall : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("callSendIntPlusInt")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Outgoing;
    [UnityEngine.Serialization.FormerlySerializedAs("value")]
	public int Value;
	[UnityEngine.Serialization.FormerlySerializedAs("delay")]
	public float Delay;

    private void Awake()
    {
        CacheMethod(Incoming, (o)=> {
			StartCoroutine(Wait(o));
		});
    }

	private IEnumerator Wait(object o) {
		yield return new WaitForSeconds(Delay);
		SendIntPlusInt(o);
	}

    private void SendIntPlusInt(object o)
    {
        int i;
		if(o is int) {
			i = (int)o;
            Call(Outgoing, cachedGameObject, i + Value);
		} else if(o != null && int.TryParse(o.ToString(), out i))
        {
            Call(Outgoing, cachedGameObject, i + Value);
        }
    }
}
