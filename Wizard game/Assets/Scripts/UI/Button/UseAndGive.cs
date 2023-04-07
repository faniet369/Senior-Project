using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseAndGive : MonoBehaviour
{
    [SerializeField] GameObject useBtn;
    [SerializeField] GameObject giveBtn;
    private bool isClicked = false;
    private Button clickedButton;
    private GameObject clickedSlot;
    private int clickedButtonIndex;
    private string itemName;
    private bool isCorrectItem;

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

    public void useItem() {
        GameObject button = clickedSlot.transform.GetChild(0).gameObject;
        Destroy(button);
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.items[clickedButtonIndex] = 0;
        inventory.itemName[clickedButtonIndex] = null;
        clear();
    }

    public void giveItem() {
        GameObject button = clickedSlot.transform.GetChild(0).gameObject;
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        PlayerCollision playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
        isCorrectItem = playerCollision.dialogueTrigger.triggerDialogueGiveItem(itemName);
        if (isCorrectItem) {
            Destroy(button);
            inventory.items[clickedButtonIndex] = 0;
            inventory.itemName[clickedButtonIndex] = null;
            clear();
            inventory.AddToInventory(playerCollision.dialogueTrigger.itemButton);
        }
    }

    private void clear() {
        useBtn.SetActive(false);
        isClicked = false;
        clickedButton = null;
        clickedSlot = null;
        clickedButtonIndex = -1;
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
