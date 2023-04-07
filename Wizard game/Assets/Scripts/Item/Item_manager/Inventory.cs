using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public int[] items;
    public GameObject[] slots;
    public string[] itemName;

    public void AddToInventory(GameObject itemButton) {
        AddBtn(itemButton);
    }

    public void AddToInventory(GameObject item, GameObject itemButton) {
        AddBtn(itemButton);
        DestroyItem(item);
    }

    public void AddBtn(GameObject itemButton) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == 0) {
                items[i] = 1;
                itemName[i] = itemButton.transform.GetChild(0).GetComponent<Text>().text;
                Instantiate(itemButton, slots[i].transform, false);
                break;
            }
        }
    }

    public void DestroyItem(GameObject item) {
        Animator animator = GetComponent<Animator>();
        if (gameObject.CompareTag("Pig")) //เดี๋ยวแก้
        {
            animator.SetTrigger("PigHurt");
            Destroy(item, 1.3f);
        }
        else {
            Destroy(item);
        }
    }

}
