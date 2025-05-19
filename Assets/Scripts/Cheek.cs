using UnityEngine;

public class Cheek : MonoBehaviour
{

    [SerializeField] private ACharacter character;

    
    [SerializeField]
    private ParticleSystem popParticles;


    [SerializeField] private Transform leftCheek, rightCheek;
    
    public void Pop()
    {
        if (character.health >= 2)
        {
            Instantiate(popParticles, leftCheek.position, Quaternion.identity);
            Destroy(leftCheek.gameObject);
        }else if (character.health >= 1)
        {
            Instantiate(popParticles, rightCheek.position, Quaternion.identity);
            Destroy(rightCheek.gameObject);
        }
        else
        {
            Instantiate(popParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        character.health--;
    }
}
