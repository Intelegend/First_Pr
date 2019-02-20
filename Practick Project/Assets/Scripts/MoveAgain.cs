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
    int life=100;
    int score = 0;
    GameObject enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        Cravity();

        if(life<=0)
        {
            speedMove = 0;
        }
        if(life>=100)
        {
            life = 100;
        }
        
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
            bool b = animator.Equals("Death");
            
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
            moveVector.y = jumpForce;
            animator.SetBool("Jump", true);
        }
    }
    public void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Life " + life);
        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Health")
        {
            if(life!=100)
            {
                life += 10;
                Destroy(other.gameObject);
            }
            
        }

        if (other.gameObject.tag=="Enemy")
        {
            animator.SetBool("Damage", true);
            life -= 20;
            animator.SetBool("Damage",false);
            transform.position = enemy.transform.position;
        }
        if (life<=0)
        {
            animator.SetBool("Death",true);
        }
        if (life>0)
        {
            animator.SetBool("Death",false);
        }
    }

    public void Damage()
    {
        //smert.animator.SetBool("Attack", true); 
    }
}
