using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioClipContainerScriptable")]
public class AudioClipContainerScriptable : ScriptableObject
{
    public AudioClip[] audioClips;
}