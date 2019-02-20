using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawn : MonoBehaviour
{
    public GameObject life;
    public Transform lifePos;
    private float repetate = 5000.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("LiveSpawner", 10f, repetate);
            //Destroy(gameObject, 11);
           // gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }

    void LiveSpawner()
    {
        Instantiate(life, lifePos.position, lifePos.rotation);

    }
}