using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	private bool on;
	public bool On
	{
		get
		{
			return on;
		}
		set
		{
			on = value;
			Target.material = on ? OnMat : OffMat;
		}
	}

	public Material OnMat, OffMat;
	public Renderer Target;

}
