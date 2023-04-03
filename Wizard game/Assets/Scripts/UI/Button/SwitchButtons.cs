using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour
{
    private Inventory inventory;
    //private static SwitchButtons instance;
    public Button[] buttons;

    // public void GetButtons() {
    //     GameObject[] allSlots = inventory.slots;
    //     int i = 0;
    //     foreach (GameObject slot in allSlots) {
    //         if (inventory.items[i] != 0) {
    //             GameObject child = slot.transform.GetChild(0).gameObject;
    //             Button button = child.GetComponent<Button>();
    //             buttons[i] = button;
    //         }
    //         i++;
    //     }
    // }
 
    public void SetAllButtonsInteractable() {
        foreach (Button button in buttons) {
            if (button != null) {
                button.interactable = true;
            }
        }
    }
 
    public void OnButtonClicked(Button clickedButton) {
        // inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        GetButtonFromInventory getButtonFromInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<GetButtonFromInventory>();
        //getButtonFromInventory.GetButtons();
        buttons = getButtonFromInventory.buttons;
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);
        SetAllButtonsInteractable();
        clickedButton.interactable = false;
        UseAndGive useAndGive = GameObject.FindGameObjectWithTag("Inventory").GetComponent<UseAndGive>();
        useAndGive.buttonIsNowClicked(clickedButton, buttonIndex);
    }

    // public static SwitchButtons GetInstance() {
    //     return instance;
    // }

    // private void Awake() {
    //     if (instance != null)
    //     {
    //         Debug.LogWarning("Found more than one instance in the scene");
    //     }
    //     instance = this;
    //     Debug.Log("ตื่่นๆๆๆ");
    // }
}
