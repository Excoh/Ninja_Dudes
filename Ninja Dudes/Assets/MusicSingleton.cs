using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(AudioSource))]
class MusicSingleton : MonoBehaviour
{
    private static MusicSingleton instance = null;
    public static MusicSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (MusicSingleton)FindObjectOfType(typeof(MusicSingleton));
            }
            return instance;
        }
    }

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}