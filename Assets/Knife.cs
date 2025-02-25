using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float pointsScored;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
        
            print("You Hit the target and scored " + pointsScored + " points!");
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
