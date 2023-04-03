using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseAndGive : MonoBehaviour
{
    [SerializeField] Button useBtn;
    [SerializeField] Button giveBtn;
    private bool isClicked = false;
    private Button clickedButton;
    private GameObject clickedSlot;
    private int clickedButtonIndex;

    private void checkDialogueIsPlaying() {
        if (DialogueManager.GetInstance().dialogueIsPlaying && isClicked) {
            giveBtn.interactable = true;
        }
        else {
            giveBtn.interactable = false;
        }
    }

    private void checkButtonIsClicked() {
        // SwitchButtons switchButtons = gameObject.GetComponent<SwitchButtons>();
        // Button[] buttons = switchButtons.buttons;
        GetButtonFromInventory getButtonFromInventory = gameObject.GetComponent<GetButtonFromInventory>();
        Button[] buttons = getButtonFromInventory.buttons;
        GameObject[] allSlots = getButtonFromInventory.allSlots;
        //Button[] buttons = SwitchButtons.GetInstance().buttons;
        foreach (Button button in buttons) {
            if (button != null) {
                if (button.interactable == false) { //button is clicked
                    isClicked = true;
                    clickedButton = button;
                    clickedButtonIndex = System.Array.IndexOf(buttons, clickedButton);
                    clickedSlot = allSlots[clickedButtonIndex];
                    useBtn.interactable = true;
                }
            }
        }
    }

    private void IsClicked() {
        if (isClicked) {
            useBtn.interactable = true;
        }
        else {
            useBtn.interactable = false;
        }
    }

    public void useItem() {
        GameObject child = clickedSlot.transform.GetChild(0).gameObject;
        Destroy(child);
        //GetButtonFromInventory getButtonFromInventory = gameObject.GetComponent<GetButtonFromInventory>();
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.items[clickedButtonIndex] = 0;
        // getButtonFromInventory.buttons[clickedButtonIndex] = null;
        // getButtonFromInventory.allSlots[clickedButtonIndex] = null;
        clear();
    }

    public void giveItem() {
        GameObject child = clickedSlot.transform.GetChild(0).gameObject;
        Destroy(child);
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.items[clickedButtonIndex] = 0;
        clear();
    }

    private void clear() {
        useBtn.interactable = false;
        isClicked = false;
        clickedButton = null;
        clickedSlot = null;
        clickedButtonIndex = -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        useBtn.interactable = false;
        giveBtn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkButtonIsClicked();
        IsClicked();
        checkDialogueIsPlaying();
    }
}
