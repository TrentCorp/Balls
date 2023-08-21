using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    //ENCAPSULATION
    public int enemyCount { get; protected set; }
    public Rigidbody enemyRb;
    protected GameObject player;

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

    //Destroy enemy if position is found lower than this on y axis
    public void Destroyed()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    //ABSTRACTION
    //Target player and move at them
    protected virtual void EnemyTargeter()
    {
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized);
        enemyRb.AddForce(lookDirection * speed);
    }
}
