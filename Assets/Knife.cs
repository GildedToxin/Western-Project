using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class Knife : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public float pointsScored;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            if (collision.transform.GetComponent<DisableTarget>().isHit) return;
            print("You Hit the target and scored " + pointsScored + " points!");
            ScoreController.Instance.AddScore(pointsScored, this.transform);

            collision.transform.GetComponent<DisableTarget>().OnHit();
            FindAnyObjectByType<SpawnWeapon>().SpawnItem();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            FindAnyObjectByType<SpawnWeapon>().SpawnItem();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Yellow"))
        {
            print("you got 50 points!");
            pointsScored = 50;
            
        }
        else if (other.gameObject.CompareTag("Blue"))
        {
            print("you got 30 points!");
            pointsScored = 30;
        }
        else if (other.gameObject.CompareTag("White"))
        {
            print("you got 20 points!");
            pointsScored = 20;
        }
        else if (other.gameObject.CompareTag("Red"))
        {
            print("you got 10 points!");
            pointsScored = 10;

        }
    }
}
