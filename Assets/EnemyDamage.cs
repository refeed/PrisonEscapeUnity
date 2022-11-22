using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

    bool playerInRange = false;

    GameObject thePlayer;
    playerHealth thePlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        //nextDamage = Time.time;
        //thePlayer = GameObject.FindGameObjectWithTag("Player");
        //thePlayerHealth = thePlayer.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange) Attack();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Attack() {
        if (nextDamage <= Time.time) {
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(thePlayer.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector3 pushDirection = new Vector3(0, (pushedObject.position.y - transform.position.y), 0).normalized;
        pushDirection *= pushBackForce;

        Rigidbody PushedRB = pushedObject.GetComponent<Rigidbody>();
        PushedRB.velocity = Vector3.zero;
        PushedRB.AddForce(pushDirection, ForceMode.Impulse);
    }


}
