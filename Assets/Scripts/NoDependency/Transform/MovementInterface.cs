using UnityEngine;

public class MovementInterface : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("onStop")]
	public string OutgoingOnStop;
	[UnityEngine.Serialization.FormerlySerializedAs("onMove")]
	public string OutgoingOnMove;
	[UnityEngine.Serialization.FormerlySerializedAs("movementThreshold")]
	public float MovementThreshold = 0.1f;
	[UnityEngine.Serialization.FormerlySerializedAs("skipNext")]
	public bool SkipNext = true;

    [UnityEngine.Serialization.FormerlySerializedAs("sendTo")]
	public Behaviour SendTo;
	private Vector3 previousPosition;

	private bool moving = false;
	public bool Moving
	{
		get {
			return moving;
		}

		set {
			if(moving != value) {
				if(moving) {
					OnMove();
				} else {
					OnStop();
				}
			}
			moving = value;
		}
	}


	private void Start()
	{
		previousPosition = cachedTransform.position;
	}

	private void Update()
	{
		Vector3 currentPosition = cachedTransform.position;
		float distance = Vector3.Distance(currentPosition, previousPosition);
		previousPosition = currentPosition;

		if(SkipNext) {
			SkipNext = false;
			return;
		}

		Moving = distance > MovementThreshold;
	}

	private void OnStop()
	{
		Send(SendTo, OutgoingOnStop);
	}

	private void OnMove()
	{
		Send(SendTo, OutgoingOnMove);
	}

	private void Send(Behaviour b, string method)
	{
		switch(b)
		{
			case Behaviour.All:
				Call(method, typeof(Base));
				break;
			case Behaviour.Self:
				Call(method, cachedGameObject);
				break;
		}
	}

	public enum Behaviour
    {
        Self,
        All
    }
}
