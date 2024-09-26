using UnityEngine;
using System.Collections;

public class Indestructible : MonoBehaviour {
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}
