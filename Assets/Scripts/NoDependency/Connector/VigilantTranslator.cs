using UnityEngine.Serialization;

public class VigilantTranslator: Base {

	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		base.OnEnable();

		CacheMethod(Incoming, (o)=> {
			Call(Outgoing, cachedGameObject, o);
		});
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
}
