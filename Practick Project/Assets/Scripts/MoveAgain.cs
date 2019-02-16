using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgain : MonoBehaviour
{
    public float speedMove;
    public float jumpForce;
    public float gravityForce;
    public Vector3 moveVector;
    public CharacterController controller;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        Cravity();
    }

    public void CharacterMove()
    {
        if(controller.isGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
            moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Horizontal") * speedMove;
            moveVector.z = Input.GetAxis("Vertical") * speedMove;


            if (moveVector.x != 0 || moveVector.z!= 0)
            {
                animator.SetBool("Move", true);
            }
            else
            {
                animator.SetBool("Move", false);
            }
            if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
            {
                Vector3 dir = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
                transform.rotation = Quaternion.LookRotation(dir);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Crouch", true);

            }
            else animator.SetBool("Crouch", false);
        }
        else
        {
            if (gravityForce < -3f)
            {
                animator.SetBool("Fall", true);
            }
        }
        
        moveVector.y = gravityForce;
        controller.Move(moveVector * Time.deltaTime);

    }
    public void Cravity()
    {
        if(!controller.isGrounded)
        {
            gravityForce -= 20f * Time.deltaTime;
        }
        else
        {
            gravityForce -= 1f;
        }

        if(Input.GetKeyDown(KeyCode.Space)&& controller.isGrounded)
        {
            gravityForce = -jumpForce;
            animator.SetBool("Jump", true);
        }
    }
}
