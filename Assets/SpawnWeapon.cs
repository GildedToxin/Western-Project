using UnityEngine;
using System.Collections;

public class SpawnWeapon : MonoBehaviour
{
    public GameObject objectPrefab; // Object prefab to spawn
    private GameObject spawnedObject; // Reference to the spawned object

    public float spawnTimer;
    public bool spawn;

    private void Update()
    {
        
    


        /*
        if (transform.childCount > 1)
        {
            
            int count = transform.childCount;

            // Start from index 1 to skip the first child
            for (int i = 1; i < count; i++)
            {
                Transform child = transform.GetChild(i);
                Destroy(child.gameObject);
            }
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Knife>())
        {
            print(other.GetComponent<Rigidbody>().useGravity);
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<test>().enabled = false;

        }
    }

    public void SpawnItem()
    {
        StartCoroutine(MyTwoSecondCoroutine());

    }
    public IEnumerator MyTwoSecondCoroutine()
    {
        
        yield return new WaitForSeconds(2f);
        spawnedObject = Instantiate(objectPrefab, transform.position + Vector3.up * .25f , transform.rotation);
    }
}
