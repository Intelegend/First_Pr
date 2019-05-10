using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject gameobjective;
    public SpriteRenderer[] SpriteGroup;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        SpriteGroup = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponentsInChildren<SpriteRenderer>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            
             collision.transform.position= gameobjective.transform.position;
            Invoke("Destroy", 1f);
            
        }
    }

    void Destroy()
    {
        Destroy(gameobjective);
    }
}
