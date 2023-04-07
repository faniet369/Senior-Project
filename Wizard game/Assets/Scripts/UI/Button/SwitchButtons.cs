using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour
{
    private Inventory inventory;
    public Button[] buttons;
 
    public void SetAllButtonsInteractable() {
        foreach (Button button in buttons) {
            if (button != null) {
                button.interactable = true;
            }
        }
    }
 
    public void OnButtonClicked(Button clickedButton) {
        GetButtonFromInventory getButtonFromInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<GetButtonFromInventory>();
        buttons = getButtonFromInventory.buttons;
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);
        SetAllButtonsInteractable();
        clickedButton.interactable = false;
        UseAndGive useAndGive = GameObject.FindGameObjectWithTag("Inventory").GetComponent<UseAndGive>();
        useAndGive.buttonIsNowClicked(clickedButton, buttonIndex);
    }
}
