using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class MoveAgain : MonoBehaviour
{
    public float speedMove;
    public float jumpForce;
    public float gravityForce;
    public Vector3 moveVector;
    public CharacterController controller;
    public Animator animator;
    int life=100;
    Cost cost = new Cost();
    GameObject enemy;
    bool paused = false;
    public int score;

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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }

        if(cost.lifemobe==0)
        {
            score++;
        }

        
       
    }

    public void CharacterMove()
    {
        if(controller.isGrounded)
        {
            animator.SetBool("Jump",false);
            animator.SetBool("Fall",false);
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
        GUI.Box(new Rect(610, 0, 100, 30), "Score "+ Score.score);
        if (paused == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 80, 100, 30), "GameOver");
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 60, 100, 300));

            if (GUILayout.Button("Restart?", GUILayout.Width(100), GUILayout.Height(25)))
            {
                Time.timeScale = 1;
                paused = false;
                SceneManager.LoadScene(2);
            }
            GUILayout.EndArea();

            if (score == 5)
            {
                GUI.Box(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 80, 100, 30), "You win");
                GUILayout.BeginArea(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 60, 100, 300));

                if (GUILayout.Button("Exit in menu", GUILayout.Width(100), GUILayout.Height(25)))
                {
                    Time.timeScale = 1;
                    paused = false;
                    SceneManager.LoadScene(0);
                }
                GUILayout.EndArea();
            }
        }


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
            Invoke("Damage", 1);
            life -= 20;
        }
        if (life<=0)
        {
            animator.SetBool("Death",true);
            Invoke("Pause", 5);
          
        }
        if (life>0)
        {
            animator.SetBool("Death",false);
        }

    }
    public void Damage()
    {
        animator.SetBool("Damage", false);
    }

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;

        }
    }
}
