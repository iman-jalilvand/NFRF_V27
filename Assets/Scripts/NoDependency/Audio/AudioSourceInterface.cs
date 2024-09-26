using UnityEngine;
using System.Collections;

public class AudioSourceInterface : Base
{
	public AudioSource Source;
	public string CallPlayOneShot;
	public string CallPlay;
	public string CallStop;

	public bool RandomPitchOnOneShot;
	public float MinRandom, MaxRandom;

	private void Awake()
	{
		CacheMethod(CallPlayOneShot, PlayOneShot);
		CacheMethod(CallPlay, Play);
		CacheMethod(CallStop, Stop);
	}

	private void Play(object o)
	{
		Source.Play();
	}

	private void Stop(object o)
	{
		Source.Stop();
	}

	public void PlayOneShot()
	{
		PlayOneShot(null);
	}

	private void PlayOneShot(object o)
	{
		AudioClip c = Source.clip;

		GameObject go = new GameObject("One Shot Audio" + c.name);
		UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(go, UnityEngine.SceneManagement.SceneManager.GetSceneByName("essential"));

		AudioSource asource = go.AddComponent<AudioSource>();
		asource.clip = c;
		if (RandomPitchOnOneShot) {
			asource.pitch = Random.Range(MinRandom, MaxRandom);
		} else {
			asource.pitch = Source.pitch;
		}
		asource.volume = Source.volume;
		asource.outputAudioMixerGroup = Source.outputAudioMixerGroup;
		asource.spatialBlend = Source.spatialBlend;
		asource.minDistance = Source.minDistance;
		asource.maxDistance = Source.maxDistance;
		asource.Play();

		AudioReverbFilter[] filters = GetComponents<AudioReverbFilter>();
		foreach (AudioReverbFilter filter in filters) {
			AudioReverbFilter f = go.AddComponent(filter.GetType()) as AudioReverbFilter;
			f.decayHFRatio = filter.decayHFRatio;
			f.decayTime = filter.decayTime;
			f.density = filter.density;
			f.diffusion = filter.diffusion;
			f.dryLevel = filter.dryLevel;
			f.hfReference = filter.hfReference;
			f.lfReference = filter.lfReference;
			f.reflectionsDelay = filter.reflectionsDelay;
			f.reflectionsLevel = filter.reflectionsLevel;
			f.reverbDelay = filter.reverbDelay;
			f.reverbLevel = filter.reverbLevel;
			f.reverbPreset = filter.reverbPreset;
			f.room = filter.room;
			f.roomHF = filter.roomHF;
			f.roomLF = filter.roomLF;
		}

		go.transform.position = cachedOriginTransform.position;
		Destroy(go, c.length * 3 + 10);
	}
}
