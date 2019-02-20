using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    
    public Transform transformation;
    int speed = 1;
    Animator animator;
    Vector3 move;
    GameObject player;
    int lifemobe = 30;
    public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform.position);
        player.transform.LookAt(player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, transformation.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.z, 0), 0.2f);
       
        if (speed!=0)
        {
            animator.SetBool("Move", true);

        }
        else
        {
            animator.SetBool("Move", false);
        }

    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Attack", true);
        }
        animator.SetBool("Attack", false);

        if (other.gameObject.tag == "Cube")
        {
            Destroy(transform.gameObject);
            
        }
        if(other.gameObject.tag=="Bullet")
        {
            lifemobe -= 10;
            Destroy(other.gameObject);
            animator.SetBool("Damage", true);
            animator.SetBool("Damage",false);

            if (lifemobe == 0)
            {
                score++;
                animator.SetBool("Death",true);
                
                
            }
            
        }
    }


}
