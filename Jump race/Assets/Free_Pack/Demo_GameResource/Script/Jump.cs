using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector2 jumpHeight;
    public CharacterController_2D player;
    bool jumpbool = true;
  
    Rigidbody2D rg;
    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        player = GetComponent<CharacterController_2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(jumpbool)
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run

            if (Input.GetKeyDown(KeyCode.Space))  
            {
                GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);

                jumpbool = false;
              
                Invoke("ReturnBool",0.5f);
            }
            
        }
      


    }
    public void ReturnBool()
    {
        jumpbool = true;
       
        GetComponent<Rigidbody2D>().AddRelativeForce(-jumpHeight);
    }
}
