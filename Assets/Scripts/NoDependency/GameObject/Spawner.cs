using UnityEngine;
using System.Collections;

public class Spawner : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("prefab")]
	public GameObject Prefab;
	[UnityEngine.Serialization.FormerlySerializedAs("parent")]
	public Transform Parent;
	[UnityEngine.Serialization.FormerlySerializedAs("callSpawn")]
	public string Incoming; //setParent
	[UnityEngine.Serialization.FormerlySerializedAs("worldPositionStays")]
	public bool WorldPositionStays;

	private void Awake()
	{
		CacheMethod(Incoming, Spawn);
	}

	private void Spawn(object o)
	{
		GameObject go = Instantiate(Prefab);
		if (Parent != null)
		{
			go.transform.SetParent(Parent, WorldPositionStays);
		}
	}
}
