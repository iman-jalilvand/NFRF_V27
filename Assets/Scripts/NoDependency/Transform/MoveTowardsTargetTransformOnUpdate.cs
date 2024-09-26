using UnityEngine;
using System.Collections;

public class MoveTowardsTargetTransformOnUpdate : MonoBehaviour {
	[UnityEngine.Serialization.FormerlySerializedAs("speed")]
	public float Speed = 1;
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public Transform Target;
	private Transform self;
	[UnityEngine.Serialization.FormerlySerializedAs("mode")]
	public Mode CopyMode;
	void Awake() {
		self = transform;
	}
	
	void Update () {
		Vector3 pos;
		switch(CopyMode) {
			case Mode.Copy:
				pos = Target.position;
				break;
			case Mode.Lerp:
				pos = Vector3.Lerp(self.position, Target.position, Speed * Time.deltaTime);
				break;
			case Mode.MoveTowards:
				pos = Vector3.MoveTowards(self.position, Target.position, Speed * Time.deltaTime);
				break;
			default:
				pos = Vector3.zero;
				break;
        }

		self.position = pos;
	}

	public enum Mode
	{
		Lerp,
		MoveTowards,
		Copy
	}
}
