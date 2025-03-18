using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTarget : MonoBehaviour
{
    public bool isHit;
    public Collider[] colliders;
    public Material mat;
    // Start is called before the first frame update
    void Awake()
    {
       // mat = this.GetComponent<Material>();
        colliders = new Collider[4];
        for (int i = 0; i < transform.childCount; i++)
        {
            colliders[i] = transform.GetChild(i).GetComponent<Collider>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void OnHit()
    {
        mat.color = new Color(0, 0, 0);
        isHit = true;
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        StartCoroutine(EnableTarget());
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
