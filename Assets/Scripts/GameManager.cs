using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public GameObject wallToDespawn;
    public int requiredKeyCount = 2;

    private int collectedKeyCount = 0;
    private List<Key> collectedKeys = new List<Key>();

    private void Awake()
    {
        // Ensure there's only one GameManager instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectKey(GameObject keyGameObject)
    {
        Key collectedKey = keyGameObject.GetComponent<Key>();

        if (collectedKey != null && !collectedKeys.Contains(collectedKey))
        {
            collectedKeys.Add(collectedKey);
            collectedKeyCount++;

            // Check if the required number of keys has been collected
            if (collectedKeyCount >= requiredKeyCount)
            {
                // Deactivate the wall (hide it)
                if (wallToDespawn != null)
                {
                    wallToDespawn.SetActive(false);
                }
            }
        }
    }
}