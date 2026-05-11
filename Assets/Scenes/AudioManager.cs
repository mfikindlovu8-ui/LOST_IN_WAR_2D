using UnityEngine.Audio;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {


        foreach (Sound s in sounds)
        {
           s. source = s.gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;

           s.source.volume =s.volume;
           s.source.pitch =s.pitch;
           s.source.loop = s.loop;


           {


           }
        }
    }


void Start ()

    {
        Play(BigGunshot);
    }
    public void Play(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == clipName);
        if (s != null && s.source != null)
        {

        }
        Debug.LogWarning("Sound: " + clipName + " not found!");
        return;
        {
        }
    }    
    
        
}
