using UnityEngine;

public class ACharacter : MonoBehaviour
{
    public int health = 2;

    public Rigidbody rb;
    
    public void Collide()
    {
        rb.AddForce(Vector3.up * 2f);
        rb.AddExplosionForce(100f, transform.position-Vector3.up, 1000f);
    }
    
}
