using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMovingDirectionOnUpdate : MonoBehaviour {
	public Rigidbody rb;
	public Transform cachedTransform;
	public float LerpValue = 0.7f;
	void Update () {
		cachedTransform.rotation = Quaternion.Slerp(cachedTransform.rotation, Quaternion.LookRotation(rb.velocity), LerpValue);
	}
}
