using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(AudioSource))]
public class SoundOnGrab : MonoBehaviour
{
    public AudioClip grabSound;
    public AudioClip throwSound;

    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnThrow);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (grabSound != null)
            audioSource.PlayOneShot(grabSound);
    }

    private void OnThrow(SelectExitEventArgs args)
    {
        if (throwSound != null)
            audioSource.PlayOneShot(throwSound);
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnThrow);
        }
    }
}