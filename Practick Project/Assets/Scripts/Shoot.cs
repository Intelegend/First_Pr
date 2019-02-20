using UnityEngine;
using System.Collections;
public class Shoot : MonoBehaviour
{
    public float speed = 5f;
    Animator animator;
    CharacterController controller;
    public Transform pistol;
    public GameObject decal;
    public GameObject drag;
    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Debug.DrawRay(pistol.position, pistol.right * 10f + transform.up);
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Shoot",true);
            Ray ray = new Ray(pistol.position, pistol.right * 10f + transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                GameObject g = Instantiate<GameObject>(decal);
                g.transform.position = hit.point + hit.normal * 0.01f;
                g.transform.rotation = Quaternion.LookRotation(-hit.normal);
                g.transform.SetParent(hit.transform);
                Rigidbody r = hit.transform.gameObject.GetComponent<Rigidbody>();
                if (r != null)
                {
                    r.AddForceAtPosition(-hit.normal * 1000f, hit.point);
                }

            }

        }
        else
        {
            animator.SetBool("Shoot", false);
        }


    }
}

