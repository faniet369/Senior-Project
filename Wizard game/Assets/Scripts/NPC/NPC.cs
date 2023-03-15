using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public int MaxHealth = 1;
    int currentHealth;

    public static int npcsKilled = 0;
    public static int totalNPCs = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        npcsKilled = 0;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth == 0)
        {
            Die();
        }

    }

    private void Die()
    {
        //Die animation
        animator.SetTrigger("IsDead");

        //Disable npc
        this.enabled = false;

        npcsKilled++;
        Debug.Log(npcsKilled);

    }

    private void BadEnd()
    {
        if (npcsKilled >= totalNPCs)
        {
            SceneManager.LoadScene("BadEndCutscene");
        }
    }
}

