using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Range(0f, 1f)]
    [SerializeField] public float effectsStartingVolume;
    [Range(0f , 1f)]
    [SerializeField] public float musicStartingVolume;

    
    public Sound[] sounds;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }

    }

    private void Awake()
    {
        instance = this;

        if (!PlayerPrefs.HasKey("effectsVolume"))
        {
            PlayerPrefs.SetFloat("effectsVolume", effectsStartingVolume);
        }
        else
        {
            effectsStartingVolume = PlayerPrefs.GetFloat("effectsVolume");
        }

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", musicStartingVolume);
        }
        else
        {
            musicStartingVolume = PlayerPrefs.GetFloat("musicVolume");
        }



        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            if (s.isEffect)
            {
                s.source.volume = effectsStartingVolume;
            }
            else if(s.isMusic)
            {
                s.source.volume = musicStartingVolume;
            }
        }

    }

    private void Start()
    {
        AudioManager.instance.Play("MenuMusic", true);
    }

    public void Play(string name, bool loop)
    {

        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.loop = loop;
                s.source.Play();
            }
        }
    }

    public void PlayAtHalf(string name, bool loop)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.loop = loop;
                s.source.volume = s.source.volume * 0.05f;
                s.source.Play();
                //Debug.Log(s.clip.name + " " + s.source.volume);
            }
        }
    }

    public void UpdateVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }


    }

    public void UpdateEffectsVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.isEffect)
            {
                s.source.volume = volume;
            }
        }
    }

    public void UpdateMusicVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.isMusic)
            {
                s.source.volume = volume;
            }
        }
    }

    public bool SoundPlaying(string name)
    {
        bool isPlaying = false;

        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                isPlaying = s.source.isPlaying;
            }
        }
        return isPlaying;
    }

    public void StopSound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.loop = false;
                s.source.Stop();
               // Debug.Log("Deteniendo sonido" + s.clip.name + " A este volumen:" + s.source.volume);
            }
        }
    }

    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}

