using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute]
public class AudioMaterial : ScriptableObject
{
    public AudioSourceMaterialPair[] SourceAndSounds;
}

[System.SerializableAttribute]
public struct AudioSourceMaterialPair
{
    public string SourceKey;
    public AudioClip[] ResultAudio;
}
