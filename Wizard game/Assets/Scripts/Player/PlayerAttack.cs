using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask npcLayers;

    public float attackRange = 0.7f;
    public int attackDamage = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play  attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitNPC = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, npcLayers);
     
        //Damage them
        foreach(Collider2D npc in hitNPC)
        {
            Debug.Log("hit enemies" + npc.name);
            npc.GetComponent<NPC>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
