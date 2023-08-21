using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Goalkeeper : Enemy
{
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        //powerupPrefab = GameObject.Find("Powerup");
        
    }

    // Update is called once per frame
    void Update()
    {
        powerupPrefab = GameObject.Find("Powerup(Clone)");
        Destroyed();
        EnemyTargeter();
        
    }

    //POLYMORPHISM
    protected override void EnemyTargeter()
    {
        Vector3 lookDirection = ((powerupPrefab.transform.position - transform.position).normalized);
        enemyRb.AddForce(lookDirection * speed);
    }
}
