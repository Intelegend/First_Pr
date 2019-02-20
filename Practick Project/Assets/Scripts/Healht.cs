using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healht : MonoBehaviour
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
        

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Health")
        {
            life+=10;
            Destroy(other.gameObject);
        }
    }


}