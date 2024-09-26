using UnityEngine;
using System.Collections;

public class AudioSourceInterfaceWithRandomPool : Base
{
    public AudioSource Source;
    public string CallPlay;
    public AudioClip[] AudioClips;

    private void Awake()
    {
        CacheMethod(CallPlay, Play);
    }

    private void Play(object o)
    {
        AudioClip c = AudioClips[Random.Range(0, AudioClips.Length)];

        GameObject go = new GameObject("One Shot Audio" + c.name);

        AudioSource asource = go.AddComponent<AudioSource>();
        asource.clip = c;
        asource.pitch = Source.pitch;
        asource.spatialBlend = Source.spatialBlend;
        asource.minDistance = Source.minDistance;
        asource.maxDistance = Source.maxDistance;
        asource.Play();

        go.transform.position = cachedOriginTransform.position;
        Destroy(go, c.length);
    }
}
