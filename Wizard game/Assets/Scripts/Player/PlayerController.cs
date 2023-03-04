using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 vector2;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 4f;

    private Animator animator;
    private SpriteRenderer sprite;
    private float moveHorizontal = 0f;

    private enum MovementState { Idle, Run, Jumping, Falling }

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

        //Jump
        if (Input.GetButtonDown("Jump")) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        //Animation running
        if (moveHorizontal > 0f)
        {
            state = MovementState.Run;
            sprite.flipX = false;
        }
        else if (moveHorizontal < 0f)
        {
            state = MovementState.Run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        //Check if Jump or Fall
        if (rb2d.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb2d.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        animator.SetInteger("state", (int)state);
    }
}
