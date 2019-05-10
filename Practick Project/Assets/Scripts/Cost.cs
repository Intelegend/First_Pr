using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Assets.Scripts;

public class Cost : MonoBehaviour
{
    
    public Transform transformation;
    int speed = 1;
    Animator animator;
    Vector3 move;
    GameObject player;
    public int lifemobe = 30;
    
    
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
        
        if (lifemobe == 0)
        {
            
            animator.SetBool("Death", true);
            speed = 0;
            
            Invoke("Destroyer",2);
            
        }
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Attack",true);
            speed = 0;
            Invoke("False", 1);
        }
        
        
        if(other.gameObject.tag=="Bullet")
        {
            lifemobe -= 10;
            Destroy(other.gameObject);
            animator.SetBool("Damage", true);
            Invoke("False", 1);
            
            
        }
        
    }
    
    public void False()
    {
        speed = 1;
        animator.SetBool("Damage", false);
        animator.SetBool("Attack", false);
    }

    public void Destroyer()
    {
        Score.AddScore();
        Destroy(gameObject);
        
    }
    
}
