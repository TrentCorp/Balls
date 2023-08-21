using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Goalkeeper : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroyed();
        EnemyTargeter();
    }

    protected override void EnemyTargeter()
    {
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized);
        enemyRb.AddForce(lookDirection * speed);
    }
}
