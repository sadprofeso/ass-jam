using UnityEngine;

public class Cheek : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem popParticles;

    public void Pop()
    {
        popParticles.Play();
        popParticles.transform.parent = null;
        Destroy(gameObject);
    }
}
