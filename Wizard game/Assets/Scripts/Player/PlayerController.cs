using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 vector2;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Vector3 footOffset;
    [SerializeField] float footRadius;
    [SerializeField] private LayerMask groundLayerMask;

    private Animator animator;
    private SpriteRenderer sprite;
    private float moveHorizontal = 0f;

    private bool isOnGround;
    private bool canDoubleJump;

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

        //Jump & DoubleJump
        if (isOnGround)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump")) 
        {
            if (isOnGround)
            {
                Jump();
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }

        UpdateAnimationState();

        //ignore collision player Layer 7 with NPC Layer 8
        Physics2D.IgnoreLayerCollision(8, 7);

    }

    private void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }

    private void FixedUpdate()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position + footOffset, footRadius, groundLayerMask);
        isOnGround = hitCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isOnGround ? Color.green : Color.red;
        Gizmos.color = canDoubleJump && !isOnGround ? Color.blue : Gizmos.color;
        Gizmos.DrawWireSphere(transform.position + footOffset, footRadius);
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
