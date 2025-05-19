using System;
using UnityEngine;

public class Lance : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("lance hit " + other.gameObject.name);
        if (other.gameObject.CompareTag("Cheek"))
        {
            Cheek cheek = other.gameObject.GetComponent<Cheek>();
            if (cheek)
            {
                cheek.Pop();
            }
        }
    }
}