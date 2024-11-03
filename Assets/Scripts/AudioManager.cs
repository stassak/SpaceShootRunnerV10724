using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundRunner[] sounds; 
    // Start is called before the first frame update
    void Start()
    {
        foreach (SoundRunner sr in sounds)
        {
            sr.source = gameObject.AddComponent<AudioSource>();
            sr.source.clip = sr.clip;
            sr.source.loop = sr.loop;
        }

        PlaySound("MainTheme");
    }

    public void PlaySound(string name)
    {
        foreach (SoundRunner s in sounds)
        {
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }
}
