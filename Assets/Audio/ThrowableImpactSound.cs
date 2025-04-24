using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ThrowableImpactSound : MonoBehaviour
{
    public AudioClip groundImpactSound;
    public AudioClip woodImpactSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude < 1f) return; // Optional: ignore soft hits

        string tag = collision.collider.tag;

        if (tag == "Floor" && groundImpactSound != null)
        {
            audioSource.PlayOneShot(groundImpactSound);
        }
        else if (tag == "Unlabeled" && woodImpactSound != null)
        {
            audioSource.PlayOneShot(woodImpactSound);
        }
    }
}
