using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomUtility
{
	public static Vector3 onUnitCircle
	{
		get
		{
			Vector3 value = UnityEngine.Random.insideUnitCircle.normalized;
			if (value.magnitude == 0) {
				value = new Vector3(1, 0);
			}
			return new Vector3(value.x, 0, value.y);
		}
	}

	public static Vector3 GetPointInBelt(float beltCenter, float beltSize)
	{
		return RandomUtility.onUnitCircle * ((beltCenter) + UnityEngine.Random.Range(-beltSize / 2, beltSize / 2));
	}

	public static int WeightedRandom(params float[] weights)
	{
		float total = 0;
		foreach (float f in weights) {
			total += f;
		}

		float rand = UnityEngine.Random.Range(0, total);

		total = 0;
		for (int i = 0, max = weights.Length; i < max; ++i) {
			float f = weights[i];
			if (f == 0) {
				continue;
			}
			total += f;
			if (rand <= total) {
				return i;
			}
		}

		return -1;
	}
}
