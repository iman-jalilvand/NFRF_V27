using UnityEngine;
using System.Collections.Generic;

public class MovementVetorInterface : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("recordedPositionCount")]
	public int RecordedPositionCount;
    [UnityEngine.Serialization.FormerlySerializedAs("callSendAverageMovementVector")]
	public string CallSendAverageMovementVector;
    [UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Outgoing;
    [UnityEngine.Serialization.FormerlySerializedAs("sendTo")]
	public Behaviour SendTo;

    private Queue<Vector3> recordedPositions = new Queue<Vector3>();
	private Queue<float> recordedTimes = new Queue<float>();
    private Vector3 newestIN, oldestIN;
	private float newestINTimestamp, oldestINTimestamp;
    private Vector3 AverageMovementVector
    {
        get
        {
            Vector3 vec = (newestIN - oldestIN);
			float scale = 1 / (newestINTimestamp - oldestINTimestamp);
			vec.Scale(new Vector3(scale,scale,scale));
			return vec;
        }
    }

    private void Awake()
    {
		oldestINTimestamp = Time.realtimeSinceStartup;
		newestINTimestamp = Time.realtimeSinceStartup;
        CacheMethod(CallSendAverageMovementVector, SendAverageMovementVector);
    }

    private void Update()
    {
        newestIN = cachedTransform.position;
		newestINTimestamp = Time.realtimeSinceStartup;
		recordedTimes.Enqueue(newestINTimestamp);
        recordedPositions.Enqueue(newestIN);

        if(recordedPositions.Count > RecordedPositionCount)
        {
            oldestIN = recordedPositions.Dequeue();
			oldestINTimestamp = recordedTimes.Dequeue();
        }
    }

    private void SendAverageMovementVector(object o)
    {
        switch (SendTo)
        {
            case Behaviour.All:
                Call(Outgoing, typeof(Base), AverageMovementVector);
                break;
            case Behaviour.Self:
                Call(Outgoing, cachedGameObject, AverageMovementVector);
                break;
        }
    }

    public enum Behaviour
    {
        Self, 
        All
    }
}
