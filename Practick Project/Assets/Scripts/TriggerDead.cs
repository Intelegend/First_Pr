using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDead: MonoBehaviour
{
    Animator animator;
    int life = 100;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            animator.SetBool("Death", true);

        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Invoke("RestarLevel()", 3);
            life--;
            
        }
       

    }

    public void RestarLevel()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
