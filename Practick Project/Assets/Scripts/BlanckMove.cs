using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanckMove : MonoBehaviour
{
    public float x;
    public float y;
    




    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Vertical");
        y = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y + 90, 0), 0.2f);
        if (Input.GetKey(KeyCode.S))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y - 90, 0), 0.2f);
        if (Input.GetKey(KeyCode.D))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y + 180, 0), 0.2f);
        if (Input.GetKey(KeyCode.A))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y,0), 0.2f);
    }
    void FixedUpdate()
    {
       

    }
}
