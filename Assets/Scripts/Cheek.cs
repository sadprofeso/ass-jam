using UnityEngine;

public class Cheek : MonoBehaviour
{

    [SerializeField] private ACharacter character;

    
    [SerializeField]
    private ParticleSystem popParticles;

    public void Pop()
    {
        character.health--;
        Instantiate(popParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
