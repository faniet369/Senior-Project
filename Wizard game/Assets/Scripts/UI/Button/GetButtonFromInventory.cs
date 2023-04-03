using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetButtonFromInventory : MonoBehaviour
{
    private Inventory inventory;
    public Button[] buttons;
    public GameObject[] allSlots;

    public void GetButtons() {
        allSlots = inventory.slots;
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

    // Start is called before the first frame update
    void Start()
    {
        // inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        // GetButtons();
    }

    // Update is called once per frame
    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        GetButtons();
    }
}
