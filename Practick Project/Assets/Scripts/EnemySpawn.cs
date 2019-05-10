using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    private float repetate = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            InvokeRepeating("EnemySpawner", 10f, repetate);
             //Destroy(gameObject, 11);
            //gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }

    void EnemySpawner()
    {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);
        
    }

}
