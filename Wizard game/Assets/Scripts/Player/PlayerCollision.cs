using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision with trap
        if(collision.transform.tag == "Enemy")
        {
            PlayerHealth.health--;
            if(PlayerHealth.health <= 0)
            {
                Debug.Log("Game Over");
                Die();
            }
            else
            {
                Debug.Log("Hurt");
                StartCoroutine(GetHurt());
            }
        }

        //fall from platform
        if(collision.transform.tag == "FallDetection")
        {
            PlayerHealth.health = 0;
            if (PlayerHealth.health == 0)
            {
                Debug.Log("Fall from platform");
                Die();
            }
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Dead");
    }

    IEnumerator GetHurt()
    {
       Physics2D.IgnoreLayerCollision(7, 6);
       anim.SetLayerWeight(1, 1);
       yield return new WaitForSeconds(2);
       anim.SetLayerWeight(1, 0);
       Physics2D.IgnoreLayerCollision(7, 6, false);
    }
    
}
