using UnityEngine;
using System.Collections;

public class UnscaledParticleBehaviour : MonoBehaviour {
    public ParticleSystem ps;
	void Update () {
        ps.Simulate(Time.unscaledDeltaTime, true, false);
	}
}
