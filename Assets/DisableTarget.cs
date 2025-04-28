using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTarget : MonoBehaviour
{
    public bool isHit;
    public Collider[] colliders;
    public Material mat;

    [Header("Audio")]
    public AudioClip hitSound;           // Assign this in the inspector
    private AudioSource audioSource;     // Audio source component


    // Start is called before the first frame update
    void Awake()
    {
       // mat = this.GetComponent<Material>();
        colliders = new Collider[4];
        for (int i = 0; i < transform.childCount; i++)
        {
            colliders[i] = transform.GetChild(i).GetComponent<Collider>();
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void OnHit()
    {
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        //mat.color = new Color(0, 0, 0);
        //isHit = true;
        //foreach (Collider collider in colliders)
        //{
           // collider.enabled = false;
        //}
        //StartCoroutine(EnableTarget());
    }

    IEnumerator EnableTarget()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Print Hello after the wait
        mat.color = new Color(1, 1, 1);
        isHit = false;
        Debug.Log("TEST");
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }
}
