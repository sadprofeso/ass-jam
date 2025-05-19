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
            other.gameObject.GetComponent<Cheek>().Pop();
        }
    }
}
