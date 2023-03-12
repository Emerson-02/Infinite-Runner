using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed, jumpForce;
    [HideInInspector] public Rigidbody2D myRB;
    public bool isGrounded, isMoving, isDie;
    private Animator myAnimator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            transform.Translate(Vector2.right * (speed * Time.deltaTime), Space.World);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Restart()
    {
        if(isDie)
        {
            isDie = false;
            myAnimator.SetBool("Dead", false);
        }
    }

    void Die()
    {
        if(isDie)
        {
            isMoving = false;
            myAnimator.SetBool("Dead", true);
            myAnimator.SetBool("Run", false);
        }
    }

    private void Initialize()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        isGrounded = true;
        isMoving = false;
        isDie = false;

        InvokeRepeating("CheckOnGround", 0.1f, 0.1f);
        InvokeRepeating("Run", 0.1f, 0.1f);
        InvokeRepeating("Die", 0.1f, 0.1f);

    }

    void Run()
    {

        if(isMoving)
        {
            myAnimator.SetBool("Run", true);
            return;
        }
    }

    public void Jump()
    {
        if(myRB.velocity.y == 0 && isMoving)
        {
            myRB.AddForce(transform.up * jumpForce);
            isGrounded = false;
            myAnimator.SetBool("Jump", true);
        }
    }

    private void CheckOnGround()
    {
        if(myRB.velocity.y == 0 && !isGrounded)
        {
            isGrounded = true;
            myAnimator.SetBool("Jump", false);
        }
    }
}
