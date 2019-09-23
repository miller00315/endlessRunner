using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    public float speedMultiplier;

    public float speedIncleaseMilestone;

    private float speedIncleaseMilestoneStore;

    private float speedMilestoneCount;

    public float jumpForce;

    public float jumpTime;

    public bool grounded;

    private bool canDoubleJump;

    public LayerMask whatIsGround;

    public GameManager theGameManager;

    private Rigidbody2D myRigidBody;
   
   private bool stoppedJump;

    private float jumpTimeCounter;

    private Animator myAnimator;

    private float moveSpeedStore;
    private float speedMilestoneCountStore;

    public Transform groundCheck;

    public float groundCheckRadius;

    public AudioSource jumpSound;

    public AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
     //   myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncleaseMilestone;

        moveSpeedStore = moveSpeed;

        speedMilestoneCountStore = speedMilestoneCount;

        speedIncleaseMilestoneStore = speedIncleaseMilestone;

        stoppedJump = true;
    }

    // Update is called once per frame
    void Update()
    {

        grounded = IsGrounded(); 

        if(transform.position.x > speedMilestoneCount) {

            speedMilestoneCount += speedIncleaseMilestone;

            speedIncleaseMilestone = speedIncleaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
        {
            if(grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                stoppedJump = false;
                jumpSound.Play();
            }
            
            if(!grounded && canDoubleJump)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJump = false;
                canDoubleJump = false;
                jumpSound.Play();
            }
            
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJump)
        {
            if(jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }


        if( Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)){

            jumpTimeCounter = 0;
            stoppedJump = true;

        }


        if(grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        } 

        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            
            theGameManager.OnPlayerDied();
            deathSound.Play();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncleaseMilestone = speedIncleaseMilestoneStore;
        }
    }

    private bool IsGrounded(){

        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
