using UnityEngine;

public class AudioSFXManager : MonoBehaviour
{
    //Make sure these are ordered the same as in the enum at the bottom
    [SerializeField] AudioClipContainerScriptable[] soundEffects;
    
    [SerializeField] AudioSource audioSource;
    
    public static AudioSFXManager Instance;

    
    private void Awake()
    {
        Instance = this;
    }

    public void PlaySFX(int clip, SFXType sfxType)
    {
        audioSource.PlayOneShot(soundEffects[(int)sfxType].audioClips[clip]);
    }

    //Easy Workaround For Button UI Clicks
    public void MenuClick(int clipNumber)
    {
        PlaySFX(clipNumber, SFXType.UI);
    }
}

//If you add another type off SFX - it should be listed here.
public enum SFXType
{
    UI,
    GameSFX
}