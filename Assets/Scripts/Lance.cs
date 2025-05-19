using System;
using UnityEngine;

public class Lance : MonoBehaviour
{
    [SerializeField] private ACharacter character;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("lance hit " + other.gameObject.name);

        switch (other.gameObject.tag)
        {
            case "Cheek":
                Cheek cheek = other.gameObject.GetComponent<Cheek>();
                if (cheek)
                {
                    cheek.Pop();
                    character.Collide();
                }

                break;
        
            case "Player":
                if (other.gameObject.GetComponent<ACharacter>().health <= 0)
                {
                    WinLoseScreen.Instance.Lose();
                    Instantiate(character.deathParticles, other.gameObject.transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                    
                }

                break;                
            case "Enemy":

                if (other.gameObject.GetComponent<ACharacter>().health <= 0)
                {
                    WinLoseScreen.Instance.Win();
                    Instantiate(character.deathParticles, other.gameObject.transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                }
                break;
        }
        
    }
}