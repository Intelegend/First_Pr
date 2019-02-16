using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float speed = 0.1f;
    Rigidbody rigidBody;
    float vertical;
    float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rigidBody.AddForce((transform.right * horizontal) + (transform.forward * vertical) * speed / Time.deltaTime);
    }
}
