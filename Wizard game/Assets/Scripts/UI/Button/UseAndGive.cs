using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UseAndGive : MonoBehaviour
{
    [SerializeField] GameObject useBtn;
    [SerializeField] GameObject giveBtn;
    private bool isClicked = false;
    private Button clickedButton;
    private GameObject clickedSlot;
    private int clickedButtonIndex;
    private string itemName;
    private bool isDeleteWithItem = false;

    private void checkDialogueIsPlaying() {
        if (DialogueManager.GetInstance().dialogueIsPlaying && isClicked) {
            giveBtn.SetActive(true);
        }
        else {
            giveBtn.SetActive(false);
        }
    }

    public void buttonIsNowClicked(Button button, int index) {
        GetButtonFromInventory getButtonFromInventory = gameObject.GetComponent<GetButtonFromInventory>();
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        GameObject[] allSlots = getButtonFromInventory.allSlots;
        isClicked = true;
        clickedButton = button;
        clickedButtonIndex = index;
        clickedSlot = allSlots[clickedButtonIndex];
        itemName = inventory.itemName[clickedButtonIndex];
        useBtn.SetActive(true);
    }

    private bool checkUsedCorrectItem() {
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        PlayerCollision playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
        switch (itemName) {
            case "candy":
                playerHealth.AddHealth(2);
                return true;
            case "magicBook":
                SceneManager.LoadScene("WizardEndCutscene");
                return true;
            case "secretKey":
                if (playerCollision.IsCollisionWithDoor == true) {
                    GameObject.Find("Door").GetComponent<DialogueTriggerforTwo>().canActive = true;
                    return true;
                }
                return false;
            default:
            //trigger default dialogue
                return false;
        }
    }

    public void useItem() {
        GameObject button = clickedSlot.transform.GetChild(0).gameObject;
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        bool isCorrectItem = checkUsedCorrectItem();
        if (isCorrectItem) {
            Destroy(button);
            inventory.items[clickedButtonIndex] = 0;
            inventory.itemName[clickedButtonIndex] = null;
            resetValue();
        }
    }

    public void giveItem() {
        GameObject button = clickedSlot.transform.GetChild(0).gameObject;
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        PlayerCollision playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
        GameObject receiveItemButton = playerCollision.dialogueTrigger.itemButton;
        bool isCorrectItem = playerCollision.dialogueTrigger.triggerDialogueGiveItem(itemName);
        if(receiveItemButton != null) {
            isDeleteWithItem = receiveItemButton.GetComponent<ButtonDetail>().isDeleteWithItem;
        }
        //Debug.Log(isDeleteWithItem);
        //deleteItem(isCorrectItem);
        if (isCorrectItem) {
            Destroy(button);
            inventory.items[clickedButtonIndex] = 0;
            inventory.itemName[clickedButtonIndex] = null;
            if (receiveItemButton != null && isDeleteWithItem == false) {
                inventory.AddToInventory(receiveItemButton);
            }
            else if (receiveItemButton != null && isDeleteWithItem == true) {
                inventory.AddToInventory(playerCollision.collisionNPC, receiveItemButton);
            }
            resetValue();
        }
    }

    private void resetValue() {
        useBtn.SetActive(false);
        isClicked = false;
        clickedButton = null;
        clickedSlot = null;
        clickedButtonIndex = -1;
        itemName = null;
    }

    private void deleteItem(bool isCorrectItem) {
        // GameObject button = clickedSlot.transform.GetChild(0).gameObject;
        // if (isCorrectItem) {
        //     Destroy(button);
        //     inventory.items[clickedButtonIndex] = 0;
        //     inventory.itemName[clickedButtonIndex] = null;
        //     if () {
        //         inventory.AddToInventory(playerCollision.dialogueTrigger.itemButton);
        //     }
        //     resetValue();
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        useBtn.SetActive(false);
        giveBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkDialogueIsPlaying();
    }
}
