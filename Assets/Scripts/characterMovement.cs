using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class characterMovement : MonoBehaviour
{
    public Transform cam;

    //movement variables
    CharacterController characterController;

    bool running;
    bool idle;
    public float speed = 12f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;
    //Gravity variables
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField]
    bool grounded;
    public float jumpHeight = 5f;
    //Animation Variables
    public Animator animator;
   

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
       


        grounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");


        //new
        if ( vert > 0.1f || vert <= -0.1f || horiz > 0.1f || horiz <= -0.1f)
        {
            running = true;
            idle = false;
        } else
        {
            running = false;
            idle = true;
        }

        this.animator.SetBool("Running", running);
        this.animator.SetFloat("X", horiz);
        this.animator.SetFloat("Y", vert);
        this.animator.SetBool("idle", idle);

        Vector3 direction = new Vector3(horiz, 0f, vert).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDir = new Vector3(horiz, 0, vert);
            moveDir = cam.TransformDirection(moveDir);
            moveDir *= speed;
            characterController.Move(moveDir * Time.deltaTime);
            transform.rotation = cam.rotation;
        } else
        {
            idle = false;
            this.animator.SetBool("idle", idle);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

}

