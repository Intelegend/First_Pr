using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    public Transform aim;
    public GameObject point;
    public float speedAim = 100000;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Transform g = (Transform)Instantiate(aim,transform.position,transform.rotation);
            g.GetComponent<Rigidbody>().AddForce(transform.forward * speedAim);
            point.GetComponent<Light>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            point.GetComponent<Light>().enabled=false;
            Destroy(gameObject, 1f);

        }
    }
}

