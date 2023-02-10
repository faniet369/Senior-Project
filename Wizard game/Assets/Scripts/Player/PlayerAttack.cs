using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

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
    }
}
