using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MpCollector : MonoBehaviour
{
    public int memoryPieces = 0;
    public int totalmemoryPieces = 10;
    public Text MPText;
    //private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Memorypiece"))
        {
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            CollectItem();
            MPText.text = memoryPieces + "/10";
        }
    }

    //This function call when player collect item
    public void CollectItem()
    {
        memoryPieces++;

        if (memoryPieces >= totalmemoryPieces)
        {
            SceneManager.LoadScene("GoodEndCutscene");
        }
    }
}
