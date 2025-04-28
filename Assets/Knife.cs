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
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = FindAnyObjectByType<SpawnWeapon>().transform.position;
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != pos.x && transform.position.z != pos.z && GetComponent<Rigidbody>().useGravity == false)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
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

        else 
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
