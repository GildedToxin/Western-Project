using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingScore : MonoBehaviour
{
    public Camera mainCamera;
    public TMP_Text text;

    public float fadeSpeed = 0.15f;
    public float upDistance = 10f;
    private Vector3 upVector;
    public float upSpeed = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        upVector = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.forward *= -1;

        transform.position = Vector3.Lerp(transform.position, upVector, upSpeed);

        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(text.color.a, 0, fadeSpeed));

        if(text.color.a < .01f)
        {
            Destroy(this.gameObject);
        }
    }
}
