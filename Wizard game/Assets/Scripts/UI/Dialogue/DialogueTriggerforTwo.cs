using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerforTwo : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSONFirst;
    [SerializeField] private TextAsset inkJSONSecond;

    private bool playerInRange;
    private bool hasSpoken = false;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                if (!hasSpoken)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSONFirst);
                    hasSpoken = true;
                }
                else
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSONSecond);
                }
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
