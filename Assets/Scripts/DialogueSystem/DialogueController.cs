using UnityEngine;
using FMODUnity;

// @author Jake DeRoma, Discord: jaker333
public class DialogueController : MonoBehaviour
{
    public static DialogueController instance;
    public bool isPlaying;

    private DialogueData currentDialogueData;
    private int currentLinesIndex = -1;

    [SerializeField] public GameObject trigger;

    void Awake()
    {
        // Singleton Functionality
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isPlaying && DialogueUIHandler.instance.canAdvanceLine && Input.GetKeyDown(KeyCode.Space)) // Change with Correct Input here temp Space
        {
            AdvanceCurrentDialogue();
        }
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        Debug.Log("Starting Dialogue Data with ID: " + dialogueData.dialogueID);

        isPlaying = true;
        currentDialogueData = dialogueData;
        currentLinesIndex = 0;
        DialogueUIHandler.instance.DisplayLine(dialogueData.lines[currentLinesIndex]); // always index 0 at start
        FMODUnity.RuntimeManager.PlayOneShot(trigger.GetComponent<DialogueTrigger>().eventName); 
    }

    public void AdvanceCurrentDialogue()
    {
        if (currentDialogueData == null)
        {
            Debug.LogError("No Dialogue Data Set to Advance to.");
            return;
        }
            
        currentLinesIndex++;

        if (currentLinesIndex < currentDialogueData.lines.Count)
        {
            DialogueUIHandler.instance.DisplayLine(currentDialogueData.lines[currentLinesIndex]);
        }
        else
        {
            EndDialogue();
        }

        FMODUnity.RuntimeManager.PlayOneShot(trigger.GetComponent<DialogueTrigger>().eventName);
    }

    public void EndDialogue()
    {
        isPlaying = false;

        currentDialogueData = null;
        currentLinesIndex = -1;

        DialogueUIHandler.instance.ResetUI();
    }
}
