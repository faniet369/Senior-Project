using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Vector2 vector2;
    public GameObject dog;
    public GameObject dogButton;
    private SpriteRenderer sprite;
    private Animator animator;
    private enum MovementState { Idle, Run, HappyBark }
    private MovementState state;
    private float moveDirection = -1f;
    private float moveSpeed = 1f;
    private bool isCollision = false;
    private bool hamWasFound = false;
    private bool flip = false;
    private float timeRemaining = -1;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private AudioSource barkSoundEffect;

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

    // IEnumerator DelayAddInventory() {
    //     yield return new WaitForSeconds(0.5f);
    //     ItemCollector itemCollector = gameObject.GetComponent<ItemCollector>();
    //     itemCollector.itemButton = dogButton;
    //     itemCollector.item = dog;
    //     itemCollector.AddToInventory();
    // }

    private void EatHam() {
        //trigger dialogue??
        hamWasFound = true;
        state = MovementState.HappyBark;
        animator.SetInteger("state", (int)state); //long bark
        barkSoundEffect.Play();
        //StartCoroutine("DelayAddInventory");
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        List<List<float>> listPosDog = new List<List<float>>();
        listPosDog.Add(new List<float> {71.34f, 8.232492f});
        listPosDog.Add(new List<float> {95.68f, -0.7675135f});
        listPosDog.Add(new List<float> {54.51f, -15.7675f});

        var random = RandomGen.random;
        int index = random.Next(listPosDog.Count);

        val.x = listPosDog[index][0];
        val.y = listPosDog[index][1];
        dog.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 val;
        // var xPos = dog.transform.position.x;
        // var yPos = dog.transform.position.y;
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
        else if (!isCollision && hamWasFound == false){
            rb2d.velocity = new Vector2(moveDirection * moveSpeed, rb2d.velocity.y);
        }
        //delete this script when npc died
        if (animator.GetBool("IsDead")) {
            Destroy(this);
        }
    }
}
