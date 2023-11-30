using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public float rotationSpeed = 45f;

    void Update()
    {
        // Rotate the GameObject around its up axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify the manager that a key has been collected
            GameManager.Instance.CollectKey(gameObject);

            // Deactivate the key (hide it)
            gameObject.SetActive(false);
        }
    }
}