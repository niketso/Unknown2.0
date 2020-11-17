using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool isEffect = false;
    public bool isMusic = false;

    [Range(0f, 1f)]
    public float volume;
    [HideInInspector]
    public AudioSource source;
}
