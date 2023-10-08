using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] AudioClipContainerScriptable musicClips;
    [SerializeField] AudioSource audioSource;
    private void Awake()
    {
        Instance = this;
    }

    public void ChangeMusic(int musicID)
    {
        audioSource.clip = musicClips.audioClips[musicID];
        audioSource.Play();
    }
}