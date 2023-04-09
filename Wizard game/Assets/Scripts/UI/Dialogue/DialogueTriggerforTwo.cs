using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerforTwo : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] GameObject visualCue;
    public bool canActive;

    [Header("Ink JSON")]
    [SerializeField] TextAsset inkJSONFirst;
    [SerializeField] TextAsset inkJSONSecond;
    [SerializeField] TextAsset dialogueAfterGetCorrectItem;
    [SerializeField] TextAsset dialogueAfterGetWrongItem;
    [SerializeField] TextAsset dialogueAfterFinishQuest;

    [Header("Quest Item")]
    [SerializeField] string itemName;

    [Header("Receive Item")]
    public GameObject itemButton;

    [Header("Related GameObject")]
    public GameObject relatedProp;

    [Header("Trigger Ending")]
    public string ending;

    private Inventory inventory;
    private bool playerInRange;
    private bool hasSpoken = false;
    private bool hasItem = false;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && canActive)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hasItem) {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogueAfterFinishQuest);
                }
                else if (hasSpoken && inkJSONSecond != null) {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSONSecond);
                }
                else {
                    if (ending != null) {
                        Debug.Log("ending");
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSONFirst, ending);
                    }
                    else {
                        Debug.Log("no ending");
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSONFirst);
                    }
                    hasSpoken = true;
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

    public bool triggerDialogueGiveItem(string itemName) {
        if (this.itemName == itemName) {
            DialogueManager.GetInstance().EnterDialogueMode(dialogueAfterGetCorrectItem);
            hasItem = true;
            return true;
        }
        else {
            DialogueManager.GetInstance().EnterDialogueMode(dialogueAfterGetWrongItem);
            return false;
        }
    }
}
