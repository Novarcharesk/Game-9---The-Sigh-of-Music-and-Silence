using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour
{
    public GameObject bridgePrefab;
    private bool canActivateBridge = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone. Press 'E' to activate the bridge.");

            canActivateBridge = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset the flag when the player exits the trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone.");
            canActivateBridge = false;
        }
    }

    private void Update()
    {
        // Check if the player is in the trigger zone and pressed the 'E' key
        if (canActivateBridge && Input.GetKeyDown(KeyCode.E))
        {
            ActivateBridge();
        }
    }

    private void ActivateBridge()
    {
        Debug.Log("Activating Bridge...");
        // Activate the bridge GameObject
        bridgePrefab.SetActive(true);

        Debug.Log("Bridge activated successfully!");
    }
}