using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public GameObject item;
    //private AudioSource collectionSoundEffect;
    private bool IsCollision;

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update() {
        if (IsCollision && Input.GetKeyDown(KeyCode.G)) {
            for (int i = 0; i < inventory.items.Length; i++) {
                if (inventory.items[i] == 0) {
                    inventory.items[i] = 1;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    //collectionSoundEffect.Play();
                    Destroy(item);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Player")) {
            IsCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        IsCollision = false;
    }
}
