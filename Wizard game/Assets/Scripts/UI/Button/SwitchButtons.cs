using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour
{
    private Inventory inventory;
    public Button[] buttons;

    public void GetButtons() {
        GameObject[] allSlots = inventory.slots;
        int i = 0;
        foreach (GameObject slot in allSlots) {
            if (inventory.items[i] != 0) {
                GameObject child = slot.transform.GetChild(0).gameObject;
                Button button = child.GetComponent<Button>();
                buttons[i] = button;
            }
            i++;
        }
    }
 
    public void SetAllButtonsInteractable() {
        foreach (Button button in buttons) {
            if (button != null) {
                button.interactable = true;
            }
        }
    }
 
    public void OnButtonClicked(Button clickedButton) {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        GetButtons();
        //int buttonIndex = buttons.IndexOf(clickedButton);
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);
        // if (buttonIndex == -1)
        //     return;
        SetAllButtonsInteractable();
        clickedButton.interactable = false;
    }
}
