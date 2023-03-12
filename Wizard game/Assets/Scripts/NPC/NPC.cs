using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public int MaxHealth = 1;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("NPC died!");
        //Die animation
        animator.SetTrigger("IsDead");

        //Disable npc
        this.enabled = false;
    }

   
}
