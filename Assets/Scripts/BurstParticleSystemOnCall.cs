using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BurstParticleSystemOnCall : Base
{
	public ParticleSystem ps;
	public string CallBurst;
	public float time = 0;
	public float count = 5;
	private void Awake()
	{
		CacheMethod(CallBurst, Burst);
	}

	private void Burst(object o)
	{
		ps.Play();
		EmissionModule em = ps.emission;
		em.enabled = true;
		ps.emission.SetBurst(0, new ParticleSystem.Burst(time, count));
	}
}
