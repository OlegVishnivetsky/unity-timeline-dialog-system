using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private DialogDisplayer dialogDisplayer;

    private void OnEnable()
    {
        dialogDisplayer.OnMaxVisibleCharactersSet += PlayAudioClip;
    }

    private void OnDisable()
    {
        dialogDisplayer.OnMaxVisibleCharactersSet -= PlayAudioClip;
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        if (audioClip != audioSource.clip)
            audioSource.clip = audioClip;

        audioSource.Play();
    }
}