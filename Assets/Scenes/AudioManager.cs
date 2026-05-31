using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundData[] sounds;

    public void Play(string soundName)
    {
        SoundData s = System.Array.Find(sounds, sound => sound.name == soundName);

        if (s == null)
        {
            Debug.LogWarning("Sound not found: " + soundName);
            return;
        }

        s.source.Play();
    }

    private void ExampleUsage()
    {
        Play("BigGunshot");
    }
}