using UnityEngine;


public class SpawnObjectOnHandEnter : MonoBehaviour
{
    public GameObject objectPrefab; // Object prefab to spawn
    private GameObject spawnedObject; // Reference to the spawned object

    private void OnTriggerEnter(Collider other)
    {
        // Check if the hand entered the trigger (using tag to identify the hand)
        if (other.CompareTag("PlayerHand"))
        {
            // Spawn the object at the trigger position
            spawnedObject = Instantiate(objectPrefab, transform.position, transform.rotation);

            // Disable the mesh renderer to hide the object initially
            Renderer renderer = spawnedObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false; // Hide the mesh renderer
            }

            // Disable gravity by making the rigidbody kinematic
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Disable gravity
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the hand leaves the collider, destroy the object if it's not grabbed
        if (other.CompareTag("PlayerHand") && spawnedObject != null)
        {
            // Check if the object is grabbed
            UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = spawnedObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null && !grabInteractable.isSelected)
            {
                Destroy(spawnedObject); // Destroy the object if it's not grabbed
            }
        }
    }

    void Update()
    {
        if (spawnedObject != null)
        {
            // Check if the object is grabbed (via XRGrabInteractable)
            UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = spawnedObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                // If grabbed, enable the mesh renderer and allow gravity
                Renderer renderer = spawnedObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = true; // Show the object when grabbed
                }

                Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false; // Enable gravity when grabbed
                }
            }
        }
    }
}
