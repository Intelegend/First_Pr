﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rd.AddForce(transform.up * 14f, ForceMode2D.Impulse);
        }
    }

    public void FixedUpdate()
    {
        rd.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rd.velocity.y);
    }

}
