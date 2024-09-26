using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpRotationSelfWithRotationParameterOnCall : MonoBehaviour {
	public string CallSlerp;

	private void Awake()
	{
		
	}

	private void Slerp(object o)
	{
		Quaternion rotation = (Quaternion) o;

	}
}
