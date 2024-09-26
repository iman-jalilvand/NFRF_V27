using UnityEngine;
using System.Collections;

public class SendRandomIntInRangeOnCall : Base {
	public int Min;
	public int Max;
	private int RandomNumber {
		get {
			return UnityEngine.Random.Range(Min, Max);
		}
	}

	public string Incoming;
	public string Outgoing;

	private void Awake() {
		CacheMethod(Incoming, (o)=> {
			Call(Outgoing, cachedGameObject, RandomNumber);
		});
	}
}
