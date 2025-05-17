using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// @author Jake DeRoma, Discord: jaker333
public class DialogueUIHandler : MonoBehaviour
{
    public static DialogueUIHandler instance;

    [Header("UI Components")]
    public GameObject dialogueBox;
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI speakerBox;
    public Image portraitImage;
    [HideInInspector] public bool canAdvanceLine;

    [Header("Animation Settings")]
    public float scalePunch = 1.4f;
    public float characterDelay = 0.03f;
    private Coroutine typingCoroutine;

    [Header("Dialogue Audio")]
    public AudioSource dialogueBlipSource;
    private float blipCooldown = 0.05f;
    private float lastBlipTime;

    void Awake()
    {
        // Singleton Functionality
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void DisplayLine(DialogueLine dialogueLine)
    {
        if (!dialogueBox.activeSelf)
        {
            dialogueBox.SetActive(true);
        }

        // Sets the instant components of DialogueLine
        speakerBox.text = dialogueLine.speakerName;
        portraitImage.sprite = dialogueLine.portrait;

        // Types text in textBox
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(dialogueLine.text, textBox, dialogueLine.voice));
    }

    // Animates each character from TMP from old project
    private IEnumerator TypeLine(string fullText, TextMeshProUGUI dialogueText, AudioClip voice)
    {
        canAdvanceLine = false;

        dialogueText.ForceMeshUpdate();
        dialogueText.text = "";

        for (int i = 0; i < fullText.Length; i++)
        {
            dialogueText.text += fullText[i];
            dialogueText.ForceMeshUpdate();

            TMP_TextInfo textInfo = dialogueText.textInfo;
            int charIndex = i;

            if (textInfo.characterCount <= charIndex)
                continue;

            TMP_CharacterInfo charInfo = textInfo.characterInfo[charIndex];
            if (!charInfo.isVisible)
                continue;

            int meshIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            Vector3[] vertices = textInfo.meshInfo[meshIndex].vertices;

            Vector3 center = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2;

            for (int j = 0; j < 4; j++)
            {
                vertices[vertexIndex + j] = center + (vertices[vertexIndex + j] - center) * scalePunch;
            }

            dialogueText.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

            TryPlayBlip(voice);

            yield return new WaitForSeconds(characterDelay);
        }

        canAdvanceLine = true;
    }

    // Plays blip sfx from old project
    private void TryPlayBlip(AudioClip clip)
    {
        if (clip == null) return;

        if (Time.time - lastBlipTime >= blipCooldown)
        {
            dialogueBlipSource.PlayOneShot(clip);
            lastBlipTime = Time.time;
        }
    }

    public void ResetUI()
    {
        textBox.text = "";
        speakerBox.text = "";
        dialogueBox.SetActive(false);
    }
}
