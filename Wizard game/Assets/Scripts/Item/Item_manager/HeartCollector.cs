using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollector : MonoBehaviour
{
    //private Health health;
    //private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Heart"))
        {
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            if (PlayerHealth.health < 3) {
                PlayerHealth.health++;
            }
        }
    }
}
