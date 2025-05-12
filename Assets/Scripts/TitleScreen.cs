using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public AudioClip backgroundMusic;

    void Start()
    {
        PersistentAudio.Instance.StopMusic();
        PersistentAudio.Instance.PlayMusic(backgroundMusic);
    }
}