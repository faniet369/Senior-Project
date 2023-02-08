using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 vector2;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private Animator animator;
    private SpriteRenderer sprite;
    private float moveHorizontal = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walk
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);
        Debug.Log(moveHorizontal);

        //Jump
        if (Input.GetButtonDown("Jump")) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        //Animation running
        if (moveHorizontal > 0f)
        {
            animator.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (moveHorizontal < 0f)
        {
            animator.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
