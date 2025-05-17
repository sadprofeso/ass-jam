using UnityEngine;
using UnityEngine.InputSystem;

// @author Jake DeRoma, Discord: jaker333

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private bool TEST_DIALOGUE_TRIGGER = false;

    void Update()
    {
        if (TEST_DIALOGUE_TRIGGER)
        {
            Trigger();
            TEST_DIALOGUE_TRIGGER = false;
        }
    }

    public void Trigger()
    {
        if (!DialogueController.instance.isPlaying)
        {
            DialogueController.instance.StartDialogue(dialogueData);
        }
        else
        {
            Debug.LogError("Attempted to Trigger Dialogue in DialogueTrigger but DialogueController was Already Displaying Dialogue");
        }
    }
}
