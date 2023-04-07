using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public GameObject item;
    //[SerializeField] private AudioSource collectionSoundEffect;
    private bool IsCollision;
    private Animator animator;

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (IsCollision && Input.GetKeyDown(KeyCode.G)) {
            //collectionSoundEffect.Play();
            AddToInventory();
        }
    }

    public void AddToInventory() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        animator = GetComponent<Animator>();

        for (int i = 0; i < inventory.items.Length; i++) {
            if (inventory.items[i] == 0) {
                inventory.items[i] = 1;
                inventory.itemName[i] = itemButton.transform.GetChild(0).GetComponent<Text>().text;
                Instantiate(itemButton, inventory.slots[i].transform, false);
                // if (gameObject.CompareTag("Pig"))
                // {
                //     animator.SetTrigger("PigHurt");
                //     Destroy(item, 1.3f);
                //     break;
                // }
                // Destroy(item);
                break;
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
