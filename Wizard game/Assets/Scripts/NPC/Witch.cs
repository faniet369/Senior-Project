using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public Vector2 vector2;
    public GameObject witch;
    private SpriteRenderer sprite;
    private Animator animator;
    private enum MovementState { Idle, Run, Attack }
    private MovementState state;
    private float moveDirection = 1f;
    private float moveSpeed = 0.5f;
    private bool isCollision = false;
    private bool butterflyWasFound = false;
    // private bool isAlreadyAttacked = false;
    private bool flip = false;
    private float timeRemaining = -1;
    [SerializeField] private Rigidbody2D rb2d;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Collider")) {
            isCollision = true;
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

    private void FoundButterfly() {
        //trigger dialogue??
        butterflyWasFound = true;
        state = MovementState.Idle;
        animator.SetInteger("state", (int)state); //long idle
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        List<List<float>> listPosWitch = new List<List<float>>();
        listPosWitch.Add(new List<float> {60.3f, -1.615153f});
        listPosWitch.Add(new List<float> {0.2000008f, -1.615131f});
        listPosWitch.Add(new List<float> {82.53f, -2.615141f});

        var random = RandomGen.random;
        int index = random.Next(listPosWitch.Count);

        val.x = listPosWitch[index][0];
        val.y = listPosWitch[index][1];
        witch.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 val;
        // var xPos = witch.transform.position.x;
        // var yPos = witch.transform.position.y;
        // val.x = xPos;
        // val.y = yPos;
        // vector2 = val;

        timeRemaining -= Time.deltaTime;

        if (isCollision && timeRemaining < 0) {
            timeRemaining = 3;
            state = MovementState.Idle;
            animator.SetInteger("state", (int)state);
            StartCoroutine("Run");
        }
        else if (!isCollision && butterflyWasFound == false){
            rb2d.velocity = new Vector2(moveDirection * moveSpeed, rb2d.velocity.y);
        }
        //delete this script when npc died
        if (animator.GetBool("IsDead")) {
            Destroy(this);
        }
    }
}
