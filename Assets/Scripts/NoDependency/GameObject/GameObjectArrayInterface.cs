using UnityEngine;
using System.Collections;

public class GameObjectArrayInterface : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("array")]
	public GameObject[] Array;
	[UnityEngine.Serialization.FormerlySerializedAs("currentIndex")]
	public int CurrentIndex;

	[UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;
	[UnityEngine.Serialization.FormerlySerializedAs("OutgoingOnOutOfRange")]
	public string OutgoingOnOutOfRange;
	[UnityEngine.Serialization.FormerlySerializedAs("callSendCurrentGameObject")]
	public string CallSendCurrentGameObject;
	[UnityEngine.Serialization.FormerlySerializedAs("callIncrementIndex")]
	public string CallIncrementIndex;

	[UnityEngine.Serialization.FormerlySerializedAs("overflow")]
	public bool Overflow = false;

	private void Awake()
	{
		CacheMethod(CallSendCurrentGameObject, SendCurrentGameObject);
		CacheMethod(Incoming, SendCurrentGameObject);
	}

	private void IncrementIndex(object o)
	{
		CurrentIndex++;
	}

	private void SendCurrentGameObject(object o)
	{
		int index = Overflow ? CurrentIndex % Array.Length : CurrentIndex;
		
		if(index >= Array.Length) {
			Call(OutgoingOnOutOfRange, cachedGameObject);
			return;
		}

		GameObject target = Array[index];
		Call(Outgoing, cachedGameObject, target);
	}
}
