using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WindAmbience : MonoBehaviour
{
    public AudioClip windClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = windClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.Play();
    }
}
