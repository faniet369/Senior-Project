using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Vector2 vector2;
    public GameObject skeleton;
    private SpriteRenderer sprite;
    private Animator animator;
    private enum MovementState { Idle, Run, Attack }
    private MovementState state;
    private float moveDirection = 1f;
    private float moveSpeed = 1.5f;
    private bool isCollision = false;
    private bool playerWasFound = false;
    private bool isAlreadyAttacked = false;
    private bool flip = false;
    private float timeRemaining = -1;
    [SerializeField] private Rigidbody2D rb2d;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Collider")) {
            isCollision = true;
        }
        if (collision.gameObject.CompareTag("Player")) {
            playerWasFound = true;
        }
    }

    IEnumerator Run() {
        yield return new WaitForSeconds(2);
        flip = !flip;
        sprite.flipX = flip;
        state = MovementState.Run;
        animator.SetInteger("state", (int)state);
        moveDirection = moveDirection * -1f;
        isCollision = false;
    }

    IEnumerator DelayIdle() {
        yield return new WaitForSeconds(2.1f);
        skeleton.transform.GetChild(0).gameObject.tag = "NPC";
        state = MovementState.Idle;
        animator.SetInteger("state", (int)state);
        Destroy(this); //delete this script
    }


    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        List<List<float>> listPosSkeleton = new List<List<float>>();
        listPosSkeleton.Add(new List<float> {17.47f, -9.447445f});
        listPosSkeleton.Add(new List<float> {-1.599999f, -9.447412f});
        listPosSkeleton.Add(new List<float> {48.63f, -17.44741f});

        var random = RandomGen.random;
        int index = random.Next(listPosSkeleton.Count);

        val.x = listPosSkeleton[index][0];
        val.y = listPosSkeleton[index][1];
        skeleton.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 val;
        // var xPos = skeleton.transform.position.x;
        // var yPos = skeleton.transform.position.y;
        // val.x = xPos;
        // val.y = yPos;
        // vector2 = val;

        timeRemaining -= Time.deltaTime;

        //attack only 1 time and idle
        if (playerWasFound && isAlreadyAttacked == false) {
            skeleton.transform.GetChild(0).gameObject.tag = "Enemy";
            state = MovementState.Attack;
            animator.SetInteger("state", (int)state);
            isAlreadyAttacked = true;
            StartCoroutine("DelayIdle");
        }

        if (isAlreadyAttacked) {
            
        }
        else if (isCollision && timeRemaining < 0) {
            timeRemaining = 3;
            state = MovementState.Idle;
            animator.SetInteger("state", (int)state);
            StartCoroutine("Run");
        }
        else if (!isCollision){
            rb2d.velocity = new Vector2(moveDirection * moveSpeed, rb2d.velocity.y);
        }

        //delete this script when npc died
        if (animator.GetBool("IsDead")) {
            Destroy(this);
        }
    }
}
