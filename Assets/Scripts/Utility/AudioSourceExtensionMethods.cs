using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioSourceExtensionMethods
{

	public static Coroutine FadeIn(this AudioSource source, float duration)
	{
		return PermanentCoroutine.Host.StartCoroutine(source.FadeRoutine(duration, 0, 1));
	}

	public static Coroutine FadeOut(this AudioSource source, float duration)
	{
		return PermanentCoroutine.Host.StartCoroutine(source.FadeRoutine(duration, 1, 0));
	}

	private static IEnumerator FadeRoutine(this AudioSource source, float duration, float from, float to)
	{
		float passed = 0;
		float delta = to - from;
		while (passed < duration) {
			float volume = from + (delta * passed / duration);
			source.volume = volume;
			passed += Time.deltaTime;
		}

		source.volume = to;
		yield return null;
	}
}
