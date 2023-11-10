using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    
    private GameObject parentNPC;
    private bool playerInRange;
    private DialogueManager dialogueManager; // Reference to the DialogueManager
    private NPC npcScript; // Reference to the NPC script

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);

        // Get references to the DialogueManager and the NPC script attached to this NPC
        dialogueManager = FindObjectOfType<DialogueManager>();
        npcScript = transform.parent.GetComponent<NPC>(); // Assuming the NPC script is on the parent GameObject
    }

    private void Update()
    {
        if (playerInRange && !dialogueManager.dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyUp(KeyCode.I))
            {
                // Set the current NPC in the DialogueManager to the NPC script
                dialogueManager.SetCurrentNPC(npcScript);
                dialogueManager.EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            parentNPC = transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
