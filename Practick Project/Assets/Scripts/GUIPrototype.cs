using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIPrototype : MonoBehaviour
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
        if(life>100)
        {
            life = 100;
        }
        
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Life " + life);
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
                life-=10;
            animator.SetBool("Damage", true);
        }
        
        animator.SetBool("Damage", false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Health")
        {
            life += 10;
        }
    }

    public void RestarLevel()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
