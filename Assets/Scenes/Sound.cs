
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound : MonoBehaviour
{
    public AudioClip clip;
    public string soundName;

    public float volume;
    [Range(0f, 1f)]
    public float pitch;

    [HideInInspector]
    public bool loop;
    public AudioSource source;
}