using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerControlPanel : MonoBehaviour
{
	public static PowerControlPanel Instance;
	private Nob[] nobs;

	private double[] power;
	public double[] Power
	{
		get
		{
			for (int i = 0, max = power.Length; i < max; ++i)
			{
				power[i] = Mathf.RoundToInt(nobs[i].Value);
			}

			return power;
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		nobs = GetComponentsInChildren<Nob>();
		power = new double[nobs.Length];
	}
}
