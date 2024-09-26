using System.Collections.Generic;
using UnityEngine;

public class AudioSourceMaterialInterface : Base
{

    public AudioSource Source;
    public AudioMaterial Material;
    public string CallPlayMaterial;
    private Dictionary<string, List<AudioClip>> MaterialClips;

    private void Awake()
    {
        CacheMethod(CallPlayMaterial, PlayMaterial);

        MaterialClips = new Dictionary<string, List<AudioClip>>();
        for (int i = 0, max = Material.SourceAndSounds.Length; i < max; ++i)
        {
            AudioSourceMaterialPair asmp = Material.SourceAndSounds[i];
            MaterialClips[asmp.SourceKey] = new List<AudioClip>(asmp.ResultAudio);
        }
    }

    private void PlayMaterial(object o)
    {
        if (o is string)
        {
            string str = o.ToString();
            if (MaterialClips.ContainsKey(str))
            {
                int i = Random.Range(0, MaterialClips[str].Count);
                Source.PlayOneShot(MaterialClips[str][i]);
            }
        }
    }
}
