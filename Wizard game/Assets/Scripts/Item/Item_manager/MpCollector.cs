using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpCollector : MonoBehaviour
{
    public int memoryPieces = 0;
    public Text MPText;
    //private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Memorypiece"))
        {
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            memoryPieces++;
            MPText.text = memoryPieces + "/10";
        }
    }
}
