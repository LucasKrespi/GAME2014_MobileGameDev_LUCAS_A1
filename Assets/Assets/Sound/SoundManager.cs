using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


// Sound Manager Based on the Code From https://www.youtube.com/watch?v=6OT43pvUyfY //

[System.Serializable]
public class Sounds
{
    public string s_name;
    public AudioClip audio;

    [Range(0.0f, 1.0f)]
    public float f_volume;
    public bool b_loop;


    [HideInInspector]
    public AudioSource a_source;
}

public class SoundManager : MonoBehaviour
{

    public Sounds[] m_sSoundArray;

    private static SoundManager soundManagerInstance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (soundManagerInstance == null)
        {
            soundManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sounds s in m_sSoundArray)
        {
            s.a_source = gameObject.AddComponent<AudioSource>();

            s.a_source.clip = s.audio;
            s.a_source.volume = s.f_volume;
            s.a_source.loop = s.b_loop;

        }
    }

    private void Start()
    {
       PlaySound("backgroundMusicMenu");
    }

    public void PlaySound(string name)
    {
        Sounds temp = Array.Find(m_sSoundArray, sound => sound.s_name == name);

        if (temp != null)
        {
            temp.a_source.Play();
        }
        else
        {
            Debug.Log("Sound not Found " + name);
        }
    }

    public void StopAllSound()
    {
        foreach(Sounds s in m_sSoundArray)
        {
            s.a_source.Stop();
        }
    }

    public static SoundManager GetSoundManagerInstance()
    {
        return soundManagerInstance;
    }
}