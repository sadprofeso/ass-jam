using UnityEngine;

public class ACharacter : MonoBehaviour
{
    public static bool canMove = false;
    
    public int health = 2;

    public Rigidbody rb;

    public ParticleSystem deathParticles;


    public void Collide()
    {
        rb.AddForce(Vector3.up * 25f);
        rb.AddExplosionForce(1000f, transform.position-Vector3.up, 1000f);
    }
    
}
