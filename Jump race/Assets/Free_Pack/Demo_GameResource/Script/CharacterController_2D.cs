using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterController_2D : MonoBehaviour {




    private bool isGrounded = false;
    public Text text;

   new public Rigidbody2D rigidbody;
   new public Animator animation;
    Transform tran;
    private float h = 0;
    private float v = 0;
    public Vector2 jumpHeight;
    public GameObject gem;
   
    public float times = 1;
    
    int speed = 250;
    
    public SpriteRenderer[] m_SpriteGroup;

    public bool Once_Attack = false;

    public GameObject cdead;

    void Start ()
    {
        cdead.SetActive(false);
        rigidbody = this.GetComponent<Rigidbody2D>();
        animation = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponent<Animator>();
        tran = this.transform;
        m_SpriteGroup = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponentsInChildren<SpriteRenderer>(true);
        
  
    }
	
	// Update is called once per frame
	void Update () {


        spriteOrder_Controller();
        
        
        
        if (animation.GetCurrentAnimatorStateInfo(0).IsName("Attack") || animation.GetCurrentAnimatorStateInfo(0).IsName("Die")||
            animation.GetCurrentAnimatorStateInfo(0).IsName("Hit")|| animation.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            return;
            Move_Fuc();
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            animation.SetFloat("MoveSpeed", Mathf.Abs(h )+Mathf.Abs (v));


        

    }

    public void FixedUpdate()
    {
       // isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
       animation.SetFloat("MoveSpeed", rigidbody.velocity.y) ;
        if (!isGrounded)
            return;

       
    }
    public int sortingOrder = 0;
    public int sortingOrderOrigine = 0;

    private float Update_Tic = 0;
    private float Update_Time = 0.1f;

    void spriteOrder_Controller()
    {

        Update_Tic += Time.deltaTime;

        if (Update_Tic > 0.1f)
        {
            sortingOrder = Mathf.RoundToInt(this.transform.position.y * 100);
            
            for (int i = 0; i < m_SpriteGroup.Length; i++)
            {

                m_SpriteGroup[i].sortingOrder = sortingOrderOrigine - sortingOrder;

            }

            Update_Tic = 0;
        }

     

    }

    // character Move Function
    void Move_Fuc()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector2.left * speed);
            if (FacingRight)
                Filp();


        }
         if (Input.GetKey(KeyCode.D))
        {
          
            rigidbody.AddForce(Vector2.right  * speed);
            if (!FacingRight)
                Filp();
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Once_Attack = false;
            animation.SetTrigger("Attack");
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Once_Attack = false;
            animation.SetTrigger("Attack2");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("1");
            animation.Play("Hit");

        }
         if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("2");
            animation.Play("Die");

        }


    }
 

    bool Attack = false;
    bool FacingRight = true;

    void Filp()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        tran.localScale = theScale;
    }
    int point = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //times -= Time.deltaTime;
        if (collision.tag=="Death")
        {
            
            animation.Play("Die");
            SceneManager.LoadScene("StartScreen");
            Destroy(gameObject, 0.5f);
            
        }

        if (collision.tag == "Fall")
        {
            
            animation.Play("Die");
            SceneManager.LoadScene("StartScreen");
            Destroy(gameObject, 0.5f);
        }
        if (collision.tag == "Gem")
        {
            point += 1;
            text.text = "" + point;
            Destroy(collision.gameObject);
        }
        

        

    }
    //   Sword,Dagger,Spear,Punch,Bow,Gun,Grenade

  


}
