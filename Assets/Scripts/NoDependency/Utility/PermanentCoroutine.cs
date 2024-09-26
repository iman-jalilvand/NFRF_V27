using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentCoroutine : MonoBehaviour
{
	public static PermanentCoroutine Host;

	private void Awake()
	{
		Host = this;
	}
}
