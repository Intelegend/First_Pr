using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float seeDistance = 5f;
    public float attackDistance = 2f;
    public float speed;
    private Transform target;
    public int healthMonster;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthMonster <= 0)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;

            Destroy(GetComponent<Rigidbody>());
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            seeDistance = 0;
            speed = 0;
            //gameObject.GetComponent<EnemyAI> ().enabled = false;
            Destroy(gameObject, 7);
        }
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
            {
                transform.LookAt(target.transform);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                gameObject.GetComponent<Animator>().SetTrigger("Move");
            }
        }
        else
        {

        }
    }
}
